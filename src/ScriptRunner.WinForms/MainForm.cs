using System.Data;
using ScriptRunner.Core.DTOS;
using ScriptRunner.WinForms.DTO;
using ScriptRunner.WinForms.IRepository.IProfileRepository;
using ScriptRunner.WinForms.IRepository.IScriptRepository;
using ScriptRunner.WinForms.IRepository.ISystemRepository;
using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms;

public partial class MainForm : Form
{
    private readonly ScriptRunner.Core.ScriptRunner _runner;
    private readonly IEScriptServices _eScriptServices;
    private readonly IProfileService _profileService;
    private readonly IExceptionLogService _exceptionLogService;
    SystemExceptions systemExceptions = null;

    public MainForm(ScriptRunner.Core.ScriptRunner runner, IEScriptServices eScriptServices, IProfileService profileService, IExceptionLogService exceptionLogService)
    {
        InitializeComponent();
        _runner = runner;
        _profileService = profileService;
        _eScriptServices = eScriptServices;
        _exceptionLogService = exceptionLogService;
    }

    private void BtnLoad_Click(object sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog { Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*" };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            txtScript.Text = File.ReadAllText(dlg.FileName);
        }
    }

    private async void BtnRun_Click(object sender, EventArgs e)
    {
        txtLog.Clear();
        ConnectionsDTO connections = new ConnectionsDTO();
        ExecutedScriptsDTO executedScriptsDTO = new ExecutedScriptsDTO();
        try
        {
            if (ProfileListBox.SelectedIndex != 0)
            {
                connections = await _profileService.GetDatabaseByID(Convert.ToInt64(DatabaseCombo.SelectedValue));


                var cts = new CancellationTokenSource(TimeSpan.FromMinutes(10));

                if (connections != null)
                {
                    executedScriptsDTO.ProfileId = connections.ProfileId;
                    executedScriptsDTO.ScriptText = txtScript.Text;
                    executedScriptsDTO.ExecutedOn = DateTime.Now;
                    executedScriptsDTO.DatabaseId = connections.DatabaseId;

                    var input = new ScriptRunnerInputs
                    {
                        scriptText = txtScript.Text,
                        EncryptedConnectionString = connections.EncryptedConnectionString,
                        Provider = connections.Provider,
                        ct = cts.Token
                    };
                    var res = await _runner.RunAsync(input);
                    if (res.Success)
                    {
                        txtLog.AppendText("Success:\r\n" + res.Output);
                        executedScriptsDTO.Status = true;
                        SaveExecutedScript(executedScriptsDTO);
                    }
                    else
                    {
                        txtScript.Text = string.Empty;
                        executedScriptsDTO.Status = false;
                        SaveExecutedScript(executedScriptsDTO);
                        txtLog.AppendText("Failed:\r\n" + res.Error?.Message + "\r\n" + res.Output);
                    }
                }
            }
            else
            {
                txtLog.AppendText("Select Profile..........");
            }
        }
        catch (Exception ex)
        {
            systemExceptions = new SystemExceptions()
            {
                ErrorMessage = ex.Message
            };
            await _exceptionLogService.SaveExceptionLog(systemExceptions);
            txtLog.AppendText("Exception: " + ex.Message + "\r\n");
        }
    }

    private async void SaveExecutedScript(ExecutedScriptsDTO executedScriptsDTO)
    {
        try
        {
            await _eScriptServices.saveScripts(executedScriptsDTO);
        }
        catch (Exception ex)
        {
            systemExceptions = new SystemExceptions()
            {
                ErrorMessage = ex.Message
            };
            await _exceptionLogService.SaveExceptionLog(systemExceptions);
        }
    }

    private void BtnProfiles_Click(object sender, EventArgs e)
    {
        OpenProfileEditDialog();
    }

    void OpenProfileEditDialog()
    {
        using var edit = new ProfileEditorForm(_profileService, _exceptionLogService);
        edit.ShowDialog(this);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoadProfiles();
    }

    public async void LoadProfiles()
    {
        try
        {
            DataTable dt = new DataTable();
            var values = await _profileService.GetAllProfiles();
            var comboboxdata = values.Select(x => new ConnectionProfileDTO
            {
                ConnectionSource = x.Item1.ConnectionSource,
                ProfileId = x.Item1.ProfileId
            }).ToList();
            if (comboboxdata == null) { OpenProfileEditDialog(); }
            else
            {

                comboboxdata.Insert(0, new ConnectionProfileDTO
                {
                    ProfileId = -1,
                    ConnectionSource = "-Select Database-"
                });
                ProfileListBox.DataSource = comboboxdata;
                ProfileListBox.DisplayMember = "ConnectionSource";
                ProfileListBox.ValueMember = "ProfileId";
            }
        }
        catch (Exception ex)
        {
            systemExceptions = new SystemExceptions()
            {
                ErrorMessage = ex.Message
            };
            await _exceptionLogService.SaveExceptionLog(systemExceptions);
        }
    }

    private async void ProfileListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            if (ProfileListBox.SelectedIndex > 0)
            {
                var profiles = await _profileService.GetDataBases(Convert.ToInt64(ProfileListBox.SelectedValue));

                profiles.connections.Insert(0, new ConnectionsDTO
                {
                    ProfileId = -1,
                    ConnectionName = "-Select Database-"
                });

                DatabaseCombo.DataSource = profiles.connections;
                DatabaseCombo.DisplayMember = "ConnectionName";
                DatabaseCombo.ValueMember = "DatabaseId";

                DatabaseCombo.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            systemExceptions = new SystemExceptions()
            {
                ErrorMessage = ex.Message
            };
            await _exceptionLogService.SaveExceptionLog(systemExceptions);
        }
    }
}
