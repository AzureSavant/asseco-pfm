﻿namespace asseco_pfm.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? BeneficaryName { get; set; }
        public DateTime Date { get; set; }
        public TransactionDirectionEnum Direction { get; set; } //to be changed with bool - not needed
        public decimal Ammount { get; set; }
        public string Description { get; set; } 
        public string Currency { get; set; }
        public int? Mcc { get; set; } 
        public TransactionKindEnum Kind { get; set; } 
        public string? Catcode { get; set; }


        public Transaction(int id, string beneficaryName, DateTime date, TransactionDirectionEnum direction, decimal ammount, string description, string currency, TransactionKindEnum kind, int? mcc)
        {
            Id = id;
            BeneficaryName = beneficaryName;
            Date = date;
            Direction = direction;
            Ammount = ammount;
            Description = description;
            Currency = currency;
            Mcc = mcc;
            Kind = kind;
        }
    }
}
