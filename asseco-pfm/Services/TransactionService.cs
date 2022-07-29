using asseco_pfm.Commands;
using asseco_pfm.Database.Repositories;
using asseco_pfm.DTO;
using asseco_pfm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace asseco_pfm.Services
{
    public class TransactionService : ITransactionService

    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionSplitSingleRepository _transactionSplitSingleRepository;

        public TransactionService(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, ITransactionSplitSingleRepository transactionSplitSingleRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
            _transactionSplitSingleRepository = transactionSplitSingleRepository;
        }


        public  Transaction AddTransaction(Transaction transaction) {

            return _transactionRepository.AddTransaction(transaction);
            
        }

        public async Task<Transaction> CategorizeTransaction(int id, TransactionCategorizeCommand transactionCategorizeCommand)
        {
            if(!_transactionRepository.IsTransactionExist(id) || !_categoryRepository.IsCategoryExist(transactionCategorizeCommand.CatCode))
            {
                return null;
            }

            var fetchedTransaction = await GetTransaction(id);
            var fetchedCategory = await _categoryRepository.GetCategoryByCodeAsync(transactionCategorizeCommand.CatCode);

            fetchedTransaction.Catcode = transactionCategorizeCommand.CatCode;
            fetchedTransaction.Category = fetchedCategory;

            var updatedTransaction = _transactionRepository.UpdateTransaction(fetchedTransaction);

            return updatedTransaction;
        }

        public async Task<Transaction> GetTransaction(int id)
        {
            return await _transactionRepository.GetTransactionById(id);
        }

        public  List<Transaction> GetTransactions(string transactionKind, DateTime? startDate, DateTime? endDate, string sortBy, int? page, int? pageSize, SortOrderEnum sortOrder)
        {
            string buildQuery = GetTransactionsBuildQuery(transactionKind, startDate, endDate, sortBy, page, pageSize, sortOrder);
            return  _transactionRepository.GetTransactionsWithCategoriesAndSplits(buildQuery);
        }
       
        public  void ImportFile(IFormFile file)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                using (var sreader = new StreamReader(file.OpenReadStream()))
                {
                    Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    string headers = sreader.ReadLine(); //split first title row
                    while (!sreader.EndOfStream)
                    {
                        string row = sreader.ReadLine();
                        string[] parsedRow=CSVParser.Split(row);
                        int Id = int.Parse(parsedRow[0]);
                        string? BeneficaryName = parsedRow[1];
                        DateTime Date = DateTime.Parse(parsedRow[2]);
                        TransactionDirectionEnum Direction = (TransactionDirectionEnum)Enum.Parse(typeof(TransactionDirectionEnum), parsedRow[3]);
                        parsedRow[4] = parsedRow[4].Replace("\"", ""); //remove "" from string
                        decimal Amount = Convert.ToDecimal(parsedRow[4]);
                        string Description = parsedRow[5];
                        string Currency = parsedRow[6];
                        int? Mcc = string.IsNullOrEmpty(parsedRow[7]) ? null : int.Parse(parsedRow[7]);
                        TransactionKindEnum Kind = (TransactionKindEnum)Enum.Parse(typeof(TransactionKindEnum), parsedRow[8]);

                        if (!_transactionRepository.IsTransactionExist(Id))
                        {
                            Transaction transactionToSave = new Transaction(Id, BeneficaryName, Date, Direction, Amount, Description, Currency, Kind, Mcc);
                            var t = AddTransaction(transactionToSave);
                        }
                    }
                }
            }
        }

        public async Task<Transaction> TransactionsSplit(int id, TransactionSplitCommand splits)
        {
            if (!_transactionRepository.IsTransactionExist(id)) 
            {
                return null;
            }

            var transaction = await GetTransaction(id);

            if (!IsSplitValid(splits, transaction.Amount))
            {
                return null;
            }

            var splitListToRemove = _transactionSplitSingleRepository.FindAllByTransactionId(transaction.Id);
            transaction.Splits = new List<TransactionSplitSingle>();

            if (splitListToRemove.Any())
            {
                splitListToRemove.ForEach(S => _transactionSplitSingleRepository.DeleteTransactionSplitSingle(S));
            }

            foreach (var transactionSplit in splits.Splits)
            {
                var category = await _categoryRepository.GetCategoryByCodeAsync(transactionSplit.CatCode);
                TransactionSplitSingle splitToSave = new TransactionSplitSingle(catCode: category.Code, amount: transactionSplit.Amount, trainsactionId: transaction.Id);
                transaction.Splits.Add(splitToSave);
            }

            var updatedTransaction = _transactionRepository.UpdateTransaction(transaction);

            return updatedTransaction;
        }

        public bool IsSplitValid(TransactionSplitCommand split,decimal amount) 
        {
            decimal sum = 0;
            foreach (var transactionSplit in split.Splits)
            {
                sum = Decimal.Add(sum, transactionSplit.Amount);
                if (!_categoryRepository.IsCategoryExist(transactionSplit.CatCode))
                {
                    return false;
                }
            }

            return IsSplitAmmountValid(amount,sum);
        }

        public bool IsSplitAmmountValid(decimal amount, decimal splitAmount)
        {
            return amount >= splitAmount;
        }

        public string GetTransactionsBuildQuery(string transactionKind, DateTime? startDate, DateTime? endDate, string sortBy, int? page, int? pageSize, SortOrderEnum sortOrder)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT * FROM transaction ");
            var expression = $"WHERE \"Kind\" = '{transactionKind}' ";
            stringBuilder.Append(expression.ToString());
            if (startDate.HasValue)
            {
                expression = $"AND \"Date\" >= '{startDate.Value.ToShortDateString()}' ";
                stringBuilder.Append(expression);
            }
            if (endDate.HasValue)
            {
                expression = $"AND \"Date\" <= '{endDate.Value.ToShortDateString()}' ";
                stringBuilder.Append(expression);
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                expression = $"ORDER BY \"{sortBy}\" {sortOrder.ToString().ToUpper()} ";
                stringBuilder.Append(expression);
            }
            expression = $"LIMIT {pageSize.ToString()}  OFFSET {((page - 1) * 10).ToString()} ";
            stringBuilder.Append(expression);
            return stringBuilder.ToString();
        } 

    }
}
