﻿using asseco_pfm.Models;

namespace asseco_pfm.Database.Repositories
{
    public interface ITransactionSplitSingleRepository
    {
        TransactionSplitSingle AddTransactionSplitSingle(TransactionSplitSingle transactionSplit);
        TransactionSplitSingle DeleteTransactionSplitSingle(TransactionSplitSingle transactionSplit);
        List<TransactionSplitSingle> FindAllByTransactionId(int transactionId);
        List<TransactionSplitSingle> GetTransactionSplitSinglesFromQuery(string query);

    }
}
