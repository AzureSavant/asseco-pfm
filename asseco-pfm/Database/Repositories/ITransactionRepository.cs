using asseco_pfm.Models;

namespace asseco_pfm.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionById(int Id);
        Task<Transaction> AddTransaction(Transaction Transaction);
        Task<Transaction> UpdateTransaction(Transaction TransactionEntity);
        void DeleteTransactionById(int Id);
        
    }
}
