using System.Runtime.Serialization;

namespace asseco_pfm.Commands
{
    public class TransactionCategorizeCommand
    {
        [DataMember(Name = "catCode")]
        public string CatCode { get; set; }
    }
}
