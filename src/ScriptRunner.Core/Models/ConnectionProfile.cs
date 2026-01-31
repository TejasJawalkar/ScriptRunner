using System.ComponentModel.DataAnnotations;

namespace ScriptRunner.Core.Models;

public class ConnectionProfile
{
    [Key]
    public Int64 ProfileId { get; set; }
    [Required]
    public string? ConnectionSource { get; set; }
    public ICollection<Databases> Databases { get; set; } = new List<Databases>();
}
