using asseco_pfm.Database.Repositories;
using asseco_pfm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace asseco_pfm.Services
{
    public class TransactionService : ITransactionService

    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }


        public  Transaction AddTransaction(Transaction transaction) {

            return _transactionRepository.AddTransaction(transaction);
            
        }

        public Transaction CategorizeTransaction(int id, string catCode)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            return await _transactionRepository.GetTransactions();
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
                        decimal Ammount = Convert.ToDecimal(parsedRow[4]);
                        string Description = parsedRow[5];
                        string Currency = parsedRow[6];
                        int? Mcc;
                        if (string.IsNullOrEmpty(parsedRow[7])){
                            Mcc = null;
                        }
                        else
                            Mcc = int.Parse(parsedRow[7]);
                        TransactionKindEnum Kind = (TransactionKindEnum)Enum.Parse(typeof(TransactionKindEnum), parsedRow[8]);

                        if (!_transactionRepository.IsTransactionExist(Id))
                        {
                            Transaction transactionToSave = new Transaction(Id, BeneficaryName, Date, Direction, Ammount, Description, Currency, Kind, Mcc);
                            var t = AddTransaction(transactionToSave);
                        }
                    }
                }
            }
        }
    }
}
