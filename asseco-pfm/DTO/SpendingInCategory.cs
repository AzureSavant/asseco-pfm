using System.Runtime.Serialization;

namespace asseco_pfm.DTO
{
    public class SpendingInCategory
    {
        [DataMember(Name = "catcode")]
        public string Catcode { get; set; }
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
        [DataMember(Name = "count")]
        public int Count { get; set; }

        public SpendingInCategory(string? catcode, decimal amount, int count)
        {
            Catcode = catcode;
            Amount = amount;
            Count = count;
        }
    }
}
