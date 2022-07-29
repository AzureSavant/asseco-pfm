using asseco_pfm.Models;

namespace asseco_pfm.Database.Repositories
{
    public class TransactionSplitSingleRepository : ITransactionSplitSingleRepository
    {
        private readonly AppDbContext _dbContext;

        public TransactionSplitSingleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TransactionSplitSingle AddTransactionSplitSingle(TransactionSplitSingle transactionSplit)
        {
            var transactionSplitSingle = _dbContext.TransactionSplitSingle.Add(transactionSplit);
            _dbContext.SaveChanges();
            return transactionSplit;

        }

        public TransactionSplitSingle DeleteTransactionSplitSingle(TransactionSplitSingle transactionSplit)
        {
            _dbContext.TransactionSplitSingle.Remove(transactionSplit);
            _dbContext.SaveChanges();
            return transactionSplit;
        }

        public List<TransactionSplitSingle> FindAllByTransactionId(int transactionId)
        {
            var listTransactions = _dbContext.TransactionSplitSingle.Where(E => E.TransactionId.Equals(transactionId)).ToList();

            return listTransactions;
        }

    }
}
