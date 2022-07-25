using System.ComponentModel.DataAnnotations.Schema;

namespace asseco_pfm.Models
{
    public class TransactionSplitSingle
    {
        public int Id { get; set; }
        public string CatCode { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        public TransactionSplitSingle( string catCode, decimal amount)
        {
            CatCode = catCode;
            Amount = amount;
        }

        public TransactionSplitSingle(string catCode, decimal amount, int trainsactionId) 
        {
            CatCode = catCode;
            Amount = amount;
            TransactionId = trainsactionId;
        }
    }
}
