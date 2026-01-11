using System.Data;
using ScriptRunner.Core.DTOS;
using ScriptRunner.Core.Models;
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
        ConnectionProfileDTO connectionProfileDTO = new ConnectionProfileDTO();
        ExecutedScriptsDTO executedScriptsDTO = new ExecutedScriptsDTO();
        try
        {
            if (ProfileListBox.SelectedIndex != 0)
            {
                connectionProfileDTO = await _profileService.GetProfileByID(Convert.ToInt64(ProfileListBox.SelectedValue));

                var cts = new CancellationTokenSource(TimeSpan.FromMinutes(10));

                if (connectionProfileDTO != null)
                {
                    ConnectionProfile cProfile = new ConnectionProfile
                    {
                        ProfileId = connectionProfileDTO.ProfileId,
                        ConnectionName = connectionProfileDTO.ConnectionName,
                        Provider = connectionProfileDTO.Provider,
                        ConnectionSource = connectionProfileDTO.ConnectionSource,
                        EncryptedConnectionString = connectionProfileDTO.EncryptedConnectionString
                    };

                    executedScriptsDTO.ProfileId = connectionProfileDTO.ProfileId;
                    executedScriptsDTO.ScriptText = txtScript.Text;
                    executedScriptsDTO.ExecutedOn = DateTime.Now;

                    var input = new ScriptRunnerInputs
                    {
                        scriptText = txtScript.Text,
                        profile = cProfile,
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
            var profiles = await _profileService.GetAllProfiles();
            if (profiles.connectionProfiles.Count == 0)
            {
                OpenProfileEditDialog();
            }
            else
            {
                profiles.connectionProfiles.Insert(0, new ConnectionProfileDTO
                {
                    ProfileId = -1,
                    ConnectionSource = "-Select Profile-"
                });

                ProfileListBox.DataSource = profiles.connectionProfiles;
                ProfileListBox.DisplayMember = "ConnectionSource";
                ProfileListBox.ValueMember = "ProfileId";

                ProfileListBox.SelectedIndex = 0;
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

    private void ProfileListBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
