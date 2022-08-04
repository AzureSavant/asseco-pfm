using asseco_pfm.Commands;
using asseco_pfm.Database.Repositories;
using asseco_pfm.DTO;
using asseco_pfm.Models;
using System.Text;

namespace asseco_pfm.Services
{
    public class AnalyticService : IAnalyticService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionSplitSingleRepository _transactionSplitSingleRepository;

        public AnalyticService(ITransactionRepository transactionRepository,ITransactionSplitSingleRepository transactionSplitSingleRepository)
        {
            _transactionRepository = transactionRepository;
            _transactionSplitSingleRepository = transactionSplitSingleRepository;
        }

        public SpendingsByCategoryDto SpendingByCategory(string catcode,List<Transaction> transactions,List<TransactionSplitSingle> splits)
        {
            
            SpendingsByCategoryDto spendingsByCategory = new SpendingsByCategoryDto();
            foreach (var transaction in transactions)
            {
                decimal amount = 0;
                int count = 0;
                SpendingInCategory spendingInCategory = new SpendingInCategory(transaction.Catcode, amount, count);

                if (!spendingsByCategory.Groups.Where(i => i.Catcode.Equals(transaction.Catcode)).Any()) {
                    foreach (var t in transactions)
                    {
                        if (t.Catcode.Equals(spendingInCategory.Catcode))
                        {
                            amount = Decimal.Add(amount, t.Amount);
                            count++;
                        }
                    }
                    spendingInCategory.Amount = amount;
                    spendingInCategory.Count = count;
                    spendingsByCategory.Groups.Add(spendingInCategory);
                }
                else
                {
                    spendingInCategory = spendingsByCategory.Groups.Where(i => i.Catcode.Equals(transaction.Catcode)).First();

                    foreach (var t in transactions)
                    {
                        if (t.Catcode.Equals(spendingInCategory.Catcode))
                        {
                            spendingInCategory.Amount = Decimal.Add(spendingInCategory.Amount, t.Amount);
                            spendingInCategory.Count++;
                        }
                    }
                    spendingsByCategory.Groups.Add(spendingInCategory);
                }
            }

            foreach (var split in splits)
            {
                decimal amount = 0;
                int count = 0;
                SpendingInCategory spendingInCategory = new SpendingInCategory(split.CatCode, amount, count);

                if (!spendingsByCategory.Groups.Where(i => i.Catcode.Equals(split.CatCode)).Any())
                {
                    foreach (var s in splits)
                    {
                        if (s.CatCode.Equals(spendingInCategory.Catcode))
                        {
                            amount = Decimal.Add(amount, s.Amount);
                            count++;
                        }
                    }
                    spendingInCategory.Amount = amount;
                    spendingInCategory.Count = count;
                    spendingsByCategory.Groups.Add(spendingInCategory);
                    
                }
                else {
                    spendingInCategory = spendingsByCategory.Groups.Where(i => i.Catcode.Equals(split.CatCode)).First();
                    foreach (var s in splits)
                    {
                        if (s.CatCode.Equals(spendingInCategory.Catcode))
                        {
                            spendingInCategory.Amount = Decimal.Add(spendingInCategory.Amount, s.Amount);
                            spendingInCategory.Count++;
                        }
                    }
                    spendingsByCategory.Groups.Add(spendingInCategory);
                }
            }

            return spendingsByCategory;
        }
        public SpendingsByCategoryDto SpendingsGet(string catcode, DateTime? startDate, DateTime? endDate, DirectionsEnum direction)
        {
            string transactionQuery = SpendingsGetBuildTransactionQuery(catcode, startDate, endDate, direction);
            string splitQuery = SpendingsGetBuildSplitQuery(catcode);
            List<Transaction> transactions = _transactionRepository.GetTransactionsFromCustomQuery(transactionQuery);
            List<TransactionSplitSingle> splits = _transactionSplitSingleRepository.GetTransactionSplitSinglesFromQuery(splitQuery);
            splits.ForEach(t => Console.WriteLine(t.Amount));
            SpendingsByCategoryDto spendingsByCategory = SpendingByCategory(catcode,transactions,splits);
            return spendingsByCategory;
        }
        public string SpendingsGetBuildTransactionQuery(string catcode, DateTime? startDate, DateTime? endDate, DirectionsEnum direction)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT * FROM transaction AS t ");

            var q = $"LEFT JOIN category AS c ON  t.\"Catcode\" = c.\"Code\"  ";
            stringBuilder.Append(q);
            q = $"WHERE t.\"Catcode\" = '{catcode}' AND t.\"Direction\" = '{direction}' OR c.\"ParentCode\" = '{catcode}'";
            stringBuilder.Append(q);
            if (startDate.HasValue)
            {
                q = $"AND t.\"Date\" >= {startDate.Value.ToShortDateString()} ";
                stringBuilder.Append(q);
            }
            if (endDate.HasValue)
            {
                q = $"AND t.\"Date\" <= {endDate.Value.ToShortDateString()} ";
                stringBuilder.Append(q);
            }
            q = $"ORDER BY t.\"Id\"";
            stringBuilder.Append(q);
            return stringBuilder.ToString();
        }
        public string SpendingsGetBuildSplitQuery(string catcode)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT * FROM transactionsplit AS t ");

            var q = $"LEFT JOIN category AS c ON  t.\"CatCode\" = c.\"Code\"  ";
            stringBuilder.Append(q);
            q = $"WHERE t.\"CatCode\" = '{catcode}' ";
            stringBuilder.Append(q);
            
            return stringBuilder.ToString();
        }
    }
}
