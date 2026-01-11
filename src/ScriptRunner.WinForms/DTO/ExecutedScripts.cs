using System.ComponentModel.DataAnnotations;
using ScriptRunner.Core.Models;

namespace ScriptRunner.WinForms.Models
{
    public class ExecutedScriptsDTO
    {
        [Key]
        public Int64 ScriptId { get; set; }
        [Required]
        public string ScriptText { get; set; }
        [Required]
        public DateTime ExecutedOn { get; set; }
        [Required]
        public Boolean Status { get; set; }
        [Required]
        public Int64 ProfileId { get; set; }

        public ExecutedScriptsDTO(ExecutedScripts executedScripts)
        {
            executedScripts.ScriptText = ScriptText;
            executedScripts.ExecutedOn = ExecutedOn;
            executedScripts.Status = Status;
            executedScripts.ProfileId = ProfileId;
        }

        public ExecutedScriptsDTO()
        {

        }

    }

}