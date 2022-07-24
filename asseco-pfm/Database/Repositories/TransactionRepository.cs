using asseco_pfm.Models;
using Microsoft.EntityFrameworkCore;

namespace asseco_pfm.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _dbContext;

        public TransactionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  Transaction AddTransaction(Transaction Transaction)
        {
             var transaction = _dbContext.Transaction.Add(Transaction);

             _dbContext.SaveChanges();

            return Transaction;
        }

        public void DeleteTransactionById(int Id)
        {
            var transaction = GetTransactionById(Id);
            if (transaction == null)
                return;

            _dbContext.Remove(transaction);
            _dbContext.SaveChanges();
        }

        public async Task<Transaction> GetTransactionById(int Id)
        {

            return await _dbContext.Transaction.FirstOrDefaultAsync(x => x.Id.Equals(Id));
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            return await _dbContext.Transaction.ToListAsync();
        }

        public  bool IsTransactionExist(int Id)
        {
            return _dbContext.Transaction.AsEnumerable().Any(t => t.Id.Equals(Id));
        }

        public Transaction UpdateTransaction(Transaction Transaction)
        {
            _dbContext.Transaction.Update(Transaction);
            _dbContext.SaveChanges();
            return Transaction;
        }
    }
}
