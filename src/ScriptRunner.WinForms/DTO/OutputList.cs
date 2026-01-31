using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms.DTO
{
    public class OutputList
    {
        public List<ConnectionProfileDTO> connectionProfiles { get; set; }

        public List<ConnectionsDTO> connections { get; set; }

        public List<Tuple<ConnectionProfileDTO, ConnectionsDTO>> Values { get; set; }
    }


    public class SystemExceptions
    {
        public string ErrorMessage { get; set; }
        public DateTime GeneratedDateTime { get; set; }
    }


}
