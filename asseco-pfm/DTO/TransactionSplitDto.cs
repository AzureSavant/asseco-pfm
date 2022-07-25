using System.Runtime.Serialization;

namespace asseco_pfm.DTO
{
    public class TransactionSplitDto
    {
        [DataMember (Name = "splits")]
        public List<TransactionSplitSingleDto> Splits { get; set; }

    }
}
