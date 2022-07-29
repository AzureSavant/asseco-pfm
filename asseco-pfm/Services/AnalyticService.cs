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
            
            SpendingsByCategoryDto spendings = new SpendingsByCategoryDto();
            decimal amount = 0;
            int count = 0;
            foreach (var transaction in transactions)
            {
                amount = Decimal.Add(amount,transaction.Amount);
                count++;
            }

            foreach (var split in splits)
            {
                if (!transactions.Contains(split.Transaction))
                {
                    amount = Decimal.Add(amount, split.Amount);
                    count++;
                }
            }
            spendings.Groups.Add(new SpendingInCategory(catcode, amount, count));
            return spendings;
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
            q = $"WHERE t.\"Catcode\" = '{catcode}' AND t.\"Direction\" = '{direction}' ";
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
