using asseco_pfm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace asseco_pfm.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetTransactions();
        Transaction AddTransaction(Transaction transaction);
        void ImportFile(IFormFile file);
        Task<Transaction> CategorizeTransaction(int id, string catCode);
    }
}
