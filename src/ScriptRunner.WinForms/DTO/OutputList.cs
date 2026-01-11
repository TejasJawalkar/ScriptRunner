using ScriptRunner.Core.Models;
using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms.DTO
{
    public class OutputList
    {
        public OutputList() { }
        public List<ConnectionProfileDTO> connectionProfiles { get; set; }
    }


    public class SystemExceptions
    {
        public string ErrorMessage { get; set; }
        public DateTime GeneratedDateTime { get; set; }

        public SystemExceptions()
        {

        }

        public SystemExceptions(ExceptionLog model)
        {
            ErrorMessage = model.ErrorMessage;
            GeneratedDateTime = model.GeneratedDateTime;
        }
    }
}
