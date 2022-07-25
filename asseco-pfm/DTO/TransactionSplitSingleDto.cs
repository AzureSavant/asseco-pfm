using System.Runtime.Serialization;

namespace asseco_pfm.DTO
{
    public class TransactionSplitSingleDto
    {
        [DataMember(Name = "catCode")]
        public string CatCode { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
    }
}
