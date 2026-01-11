using ScriptRunner.Core.Adapters;
using ScriptRunner.Core.Contracts;
using ScriptRunner.WinForms.DTO;
using ScriptRunner.WinForms.IRepository.IProfileRepository;
using ScriptRunner.WinForms.IRepository.ISystemRepository;
using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms;

public partial class ProfileEditorForm : Form
{
    private BindingSource _bs = new BindingSource();
    private readonly IProfileService _profileService;
    private readonly IExceptionLogService _exceptionLogService;

    SystemExceptions exceptions = null;

    public ProfileEditorForm(IProfileService profileService, IExceptionLogService exceptionLogService)
    {
        InitializeComponent();
        cmbProvider.Items.AddRange(new[] { "SqlServer", "Oracle" });
        _profileService = profileService;
        _exceptionLogService = exceptionLogService;
        LoadProfiles();
    }

    private async void LoadProfiles()
    {
        var profiles = await _profileService.GetAllProfiles();
        _bs.DataSource = profiles.connectionProfiles;
        lstProfiles.DisplayMember = nameof(ConnectionProfileDTO.ConnectionName);
        lstProfiles.ValueMember = nameof(ConnectionProfileDTO.ProfileId);
        lstProfiles.DataSource = _bs;
    }

    private void LstProfiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstProfiles.SelectedItem is ConnectionProfileDTO p)
        {
            txtName.Text = p.ConnectionName;
            cmbProvider.SelectedItem = p.Provider;
            txtConn.Text = p.EncryptedConnectionString;
        }
    }

    private async void BtnTest_Click(object sender, EventArgs e)
    {
        var provider = cmbProvider.SelectedItem?.ToString() ?? "";
        var cs = txtConn.Text;
        if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(cs))
        {
            MessageBox.Show("Provider and connection string are required.");
            return;
        }

        btnTest.Enabled = false;
        try
        {
            IProviderAdapter adapter = provider switch
            {
                "SqlServer" => new SqlServerAdapter(),
                _ => throw new InvalidOperationException("Unsupported provider")
            };

            using var conn = adapter.CreateConnection(cs);
            await conn.OpenAsync();
            MessageBox.Show("Connection successful.");
            await conn.CloseAsync();
        }
        catch (Exception ex)
        {
            exceptions = new SystemExceptions
            {
                ErrorMessage = ex.Message
            };
            await _exceptionLogService.SaveExceptionLog(exceptions);
            MessageBox.Show("Connection failed: " + ex.Message);
        }
        finally
        {
            btnTest.Enabled = true;
        }
    }

    private async void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var profiles = await _profileService.GetAllProfiles(); /// get all saved profile and load in textaread to select
            var existing = lstProfiles.SelectedItem as ConnectionProfileDTO;
            ConnectionProfileDTO profileDTO = new ConnectionProfileDTO();

            profileDTO.ConnectionName = txtName.Text.Trim();
            profileDTO.Provider = cmbProvider.SelectedItem?.ToString() ?? "";
            profileDTO.EncryptedConnectionString = txtConn.Text;
            profileDTO.ConnectionSource = ConnectionSourceTxt.Text.Trim() ?? "";
            profileDTO.EncryptedConnectionString = profileDTO.EncryptedConnectionString;

            if (string.IsNullOrEmpty(profileDTO.ConnectionName) || string.IsNullOrEmpty(profileDTO.Provider) || string.IsNullOrEmpty(profileDTO.EncryptedConnectionString) || string.IsNullOrEmpty(profileDTO.ConnectionSource))
            {
                MessageBox.Show("Name, provider and connection string are required.");
                return;
            }
            await SaveProfileInDB(profileDTO);
            LoadProfiles();
            MessageBox.Show("Saved.");
        }
        catch (Exception ex)
        {
            exceptions = new SystemExceptions
            {
                ErrorMessage = ex.Message
            };
            await _exceptionLogService.SaveExceptionLog(exceptions);
            MessageBox.Show("Error saving profile: " + ex.Message);
        }
    }

    private async Task<Int32> SaveProfileInDB(ConnectionProfileDTO profileDTO)
    {
        Int32 result = 0;
        try
        {
            result = await _profileService.SaveProfiles(profileDTO);
        }
        catch (Exception ex)
        {
            exceptions = new SystemExceptions
            {
                ErrorMessage = ex.Message
            };
            await _exceptionLogService.SaveExceptionLog(exceptions);
        }
        return result;
    }

    private async void BtnDelete_Click(object sender, EventArgs e)
    {

    }

    private async void ProfileEditorForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        try
        {
            if (this.Owner is MainForm mainForm)
            {
                mainForm.LoadProfiles();
            }
        }
        catch (Exception ex)
        {
            exceptions = new SystemExceptions
            {
                ErrorMessage = ex.Message
            };
            await _exceptionLogService.SaveExceptionLog(exceptions);
        }
    }
}
