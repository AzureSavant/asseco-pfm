namespace asseco_pfm.Models
{
    public class TransactionSplitSingle
    {
        public int Id { get; set; }
        public string CatCode { get; set; }
        public decimal Amount { get; set; }

        public TransactionSplitSingle( string catCode, decimal amount)
        {
            CatCode = catCode;
            Amount = amount;
        }
    }
}
