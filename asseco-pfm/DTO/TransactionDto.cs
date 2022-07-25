using asseco_pfm.Models;

namespace asseco_pfm.DTO
{
    public class TransactionDto
    {
        public string? BeneficaryName { get; set; }
        public DateTime Date { get; set; }
        public TransactionDirectionEnum Direction { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public int? Mcc { get; set; }
        public TransactionKindEnum Kind { get; set; }
        public string? Catcode { get; set; }
        public List<TransactionSplitSingle>? Splits { get; set; }
    }
}
