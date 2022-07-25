using System.Runtime.Serialization;

namespace asseco_pfm.Commands
{
    public class CatCodeCommand
    {
        [DataMember(Name = "catCode")]
        public string CatCode { get; set; }
    }
}
