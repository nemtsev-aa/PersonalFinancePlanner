using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransactionManager {
    private TransactionFactory _transactionFactory;
    private TransactionDataList _transactionDatas;

    public TransactionManager(CategoryViewConfigs configs, TransactionDataList dataList) {
        _transactionDatas = dataList;

        Transactions = new List<Transaction>();
        _transactionFactory = new TransactionFactory(configs);

        CreateTransactions();
    }

    public List<Transaction> Transactions { get; private set; }

    public void DisplayTransactions() {
        foreach (Transaction transaction in Transactions) {
            Debug.Log(transaction.ToString());
        }
    }

    private void CreateTransactions() {
        if (_transactionDatas.List.Count() == 0)
            throw new ArgumentNullException($"TransactionDataList is empty");

        foreach (var iData in _transactionDatas.List) {
            CreateTransaction(iData);
        }
    }

    private void CreateTransaction(TransactionData transactionData) {
        string id = $"{transactionData.Date}+{transactionData.Description}";

        Transaction newTransaction = new Transaction(transactionData, id);
        Transactions.Add(newTransaction);
    }
}
