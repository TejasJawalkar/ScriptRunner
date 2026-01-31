using System.ComponentModel.DataAnnotations;

namespace ScriptRunner.Core.Models
{
    public class Databases
    {
        [Key]
        public Int64 DatabaseId { get; set; }
        [Required]
        public Int64 ProfileId { get; set; }
        [Required]
        public string? Provider { get; set; }
        [Required]
        public string? ConnectionName { get; set; }
        [Required]
        public string? EncryptedConnectionString { get; set; }
        public ConnectionProfile connectionProfiles { get; set; } = null!;
        public ICollection<ExecutedScripts> ExecutedScripts { get; set; } = new List<ExecutedScripts>();
    }
}