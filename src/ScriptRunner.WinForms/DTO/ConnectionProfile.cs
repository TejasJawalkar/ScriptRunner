using System.ComponentModel.DataAnnotations;
using ScriptRunner.Core.Models;

namespace ScriptRunner.WinForms.Models;

public class ConnectionProfileDTO
{
    public Int64 ProfileId { get; set; }
    [Required]
    public string ConnectionName { get; set; }
    [Required]
    public string Provider { get; set; }
    [Required]
    public string EncryptedConnectionString { get; set; }
    [Required]
    public string ConnectionSource { get; set; }

    public ConnectionProfileDTO(ConnectionProfile model)
    {
        model.ProfileId = ProfileId;
        model.ConnectionName = ConnectionName;
        model.Provider = Provider;
        model.EncryptedConnectionString = EncryptedConnectionString;
        model.ConnectionSource = ConnectionSource;
    }

    public ConnectionProfileDTO()
    {
    }
}
