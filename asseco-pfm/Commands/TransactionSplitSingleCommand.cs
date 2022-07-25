using System.Runtime.Serialization;

namespace asseco_pfm.Commands
{
    public class TransactionSplitSingleCommand
    {
        [DataMember(Name = "catCode")]
        public string CatCode { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
    }
}
