using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransactionManager {
    private TransactionFactory _transactionFactory;
    private IEnumerable<TransactionData> _transactionDatas;

    public TransactionManager(CategoryViewConfigs configs, IEnumerable<TransactionData> transactionDatas) {
        _transactionDatas = transactionDatas;

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
        if (_transactionDatas.Count() == 0)
            throw new ArgumentNullException($"TransactionDataList is empty");

        foreach (var iData in _transactionDatas) {
            CreateTransaction(iData);
        }
    }

    private void CreateTransaction(TransactionData transactionData) {
        //Transaction newTransaction = _transactionFactory.Get(transactionData);
        //Transactions.Add(newTransaction);
    }

    
    //private void CategorizeTransactions() {
    //    foreach (Transaction transaction in Transactions) {
    //        if (transaction.Amount < 0) {
    //            transaction.SetCategory("Расход");
    //        }
    //        else if (transaction.Amount > 0) {
    //            transaction.SetCategory("Доход");
    //        }
    //        else {
    //            transaction.SetCategory("Без категории");
    //        }
    //    }
    //}
}
