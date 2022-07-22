using asseco_pfm.Models;

namespace asseco_pfm.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionById(int Id);
        Transaction AddTransaction(Transaction Transaction);
        Task<Transaction> UpdateTransaction(Transaction TransactionEntity);
        void DeleteTransactionById(int Id);
        Task<List<Transaction>> GetTransactions();
        bool IsTransactionExist(int Id);
        
    }
}
