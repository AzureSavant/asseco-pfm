using asseco_pfm.Models;

namespace asseco_pfm.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionById(int Id);
        Transaction AddTransaction(Transaction Transaction);
        Transaction UpdateTransaction(Transaction Transaction);
        void DeleteTransactionById(int Id);
        Task<List<Transaction>> GetTransactions();
        bool IsTransactionExist(int Id);
        List<Transaction> GetTransactionsWithCategoriesAndSplits(string Query);
        
    }
}
