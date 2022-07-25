using System.ComponentModel.DataAnnotations.Schema;

namespace asseco_pfm.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? BeneficaryName { get; set; }
        public DateTime Date { get; set; }
        public TransactionDirectionEnum Direction { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } 
        public string Currency { get; set; }
        public int? Mcc { get; set; } 
        public TransactionKindEnum Kind { get; set; }
        [ForeignKey("Category")]
        public string? Catcode { get; set; }
        public Category? Category { get; set; }
        public List<TransactionSplitSingle>? Splits { get; set; }

        

        public Transaction() { }
        public Transaction(int id, string beneficaryName, DateTime date, TransactionDirectionEnum direction, decimal amount, string description, string currency, TransactionKindEnum kind, int? mcc)
        {
            Id = id;
            BeneficaryName = beneficaryName;
            Date = date;
            Direction = direction;
            Amount = amount;
            Description = description;
            Currency = currency;
            Mcc = mcc;
            Kind = kind;
        }
        public Transaction(string beneficaryName, DateTime date, TransactionDirectionEnum direction, decimal amount, string description, string currency, TransactionKindEnum kind, int? mcc)
        {
            BeneficaryName = beneficaryName;
            Date = date;
            Direction = direction;
            Amount = amount;
            Description = description;
            Currency = currency;
            Mcc = mcc;
            Kind = kind;
        }
        public Transaction(string beneficaryName, DateTime date, TransactionDirectionEnum direction, decimal amount, string description, string currency, TransactionKindEnum kind, int? mcc,string? catCode, Category? category )
        {
            BeneficaryName = beneficaryName;
            Date = date;
            Direction = direction;
            Amount = amount;
            Description = description;
            Currency = currency;
            Mcc = mcc;
            Kind = kind;
            Catcode = catCode;
            Category = category;
        }
    }
}
