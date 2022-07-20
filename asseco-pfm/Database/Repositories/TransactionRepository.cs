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

        public async Task<Transaction> AddTransaction(Transaction Transaction)
        {
            _dbContext.Transaction.Add(Transaction);

            await _dbContext.SaveChangesAsync();

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

        public Task<Transaction> UpdateTransaction(Transaction TransactionEntity)
        {
            throw new NotImplementedException();
        }
    }
}
