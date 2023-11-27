using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransactionLoader {
    private const string Key = "TransactionsData";

    private SavesManager _savesManager;
    private List<Transaction> _transactions;

    public TransactionLoader() {
        _savesManager = new SavesManager(SaveType.Json, "");
    }

    public IReadOnlyList<Transaction> Transactions => _transactions;

    public void SaveTransactions(List<Transaction> transactions) {
        _savesManager.Save(Key, transactions, OnTransactionSaved);
    }

    public IReadOnlyList<Transaction> LoadTransactions() {
        LoadTransactionsFromJson();

        return Transactions;
    }

    private void LoadTransactionsFromJson() {
        _savesManager.Load<List<Transaction>>(Key, OnTransactionLoaded);
    }

    private void OnTransactionLoaded(List<Transaction> transactions) {
        if (transactions == null) {
            Debug.LogError("Load falled");
            return;
        }
        
        _transactions = transactions.ToList();
        Debug.Log("Load complited");
    }

    private void OnTransactionSaved(bool status) {
        if (status == false) {
            Debug.Log("Save falled");
            return;
        }

        Debug.Log("Save complited");
    }

    [Serializable]
    private class TransactionCollection {
        public string Info { get; set; }

        public TransactionCollection(string id) {
            Info = id;
        }
    }
}
