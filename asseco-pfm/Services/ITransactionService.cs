using asseco_pfm.Commands;
using asseco_pfm.DTO;
using asseco_pfm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace asseco_pfm.Services
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions(string transactionKind,  DateTime? startDate,  DateTime? endDate,  string sortBy,  int? page , int? pageSize, SortOrderEnum sortOrder);
        Transaction AddTransaction(Transaction transaction);
        Task<Transaction> GetTransaction(int id);
        void ImportFile(IFormFile file);
        Task<Transaction> CategorizeTransaction(int id, TransactionCategorizeCommand transactionCategorizeCommand);
        Task<Transaction> TransactionsSplit(int id, TransactionSplitCommand splits);
    }
}
