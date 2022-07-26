using asseco_pfm.Commands;
using asseco_pfm.DTO;
using asseco_pfm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace asseco_pfm.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetTransactions();
        Transaction AddTransaction(Transaction transaction);
        Task<Transaction> GetTransaction(int id);
        void ImportFile(IFormFile file);
        Task<Transaction> CategorizeTransaction(int id, CatCodeCommand catCodeCommand);
        Task<Transaction> TransactionsSplit(int id, TransactionSplitCommand splits);
    }
}
