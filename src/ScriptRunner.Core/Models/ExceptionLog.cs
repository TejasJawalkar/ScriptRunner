using System.ComponentModel.DataAnnotations;

namespace ScriptRunner.Core.Models
{
    public class ExceptionLog
    {
        [Key]
        public Int64 ExceptionId { get; set; }
        [Required]
        public string? ErrorMessage { get; set; }
        [Required]
        public DateTime GeneratedDateTime { get; set; }
    }
}
