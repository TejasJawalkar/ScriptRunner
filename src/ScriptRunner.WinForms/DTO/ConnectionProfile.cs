using System.ComponentModel.DataAnnotations;

namespace ScriptRunner.WinForms.Models;

public class ConnectionProfileDTO
{
    public Int64 ProfileId { get; set; }

    public string ConnectionSource { get; set; }
}

public class ConnectionsDTO
{
    public Int64 DatabaseId { get; set; }
    public Int64 ProfileId { get; set; }

    public string ConnectionName { get; set; }

    public string Provider { get; set; }

    public string EncryptedConnectionString { get; set; }
}


public class SavingPRofileDatabase
{
    public Int64 ProfileId { get; set; }
    [Required]
    public string ConnectionSource { get; set; }
    [Required]
    public string ConnectionName { get; set; }
    [Required]
    public string Provider { get; set; }
    [Required]
    public string EncryptedConnectionString { get; set; }

}