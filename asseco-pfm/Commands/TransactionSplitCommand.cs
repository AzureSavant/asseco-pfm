using System.Runtime.Serialization;

namespace asseco_pfm.Commands
{
    public class TransactionSplitCommand
    {
        [DataMember(Name = "splits")]
        public List<TransactionSplitSingleCommand> Splits { get; set; }
    }
}
