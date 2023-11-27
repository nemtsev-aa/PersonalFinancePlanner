using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransactionManager {
    private TransactionLoader _transactionLoader;
    private Transactions_SO _transactions_SO;

    private List<Transaction> _transactions;
    
    public TransactionManager(Transactions_SO transactions) {
        _transactionLoader = new TransactionLoader();
        _transactions_SO = transactions;
        _transactions = new List<Transaction>();

        LoadTransactionDataFromJson();
    }

    public IReadOnlyList<Transaction> Transactions => _transactions;

    public void AddTransaction(TransactionData transactionData) => Create(transactionData);

    public void RemoveTransaction(TransactionData transactionData) => Remove(transactionData);

    public void SaveTransactions() => _transactionLoader.SaveTransactions(_transactions);

    #region Filers Metod

    public List<Transaction> FilterByDate(DateTime from, DateTime to) {
        return _transactions.Where(t => t.Date >= from && t.Date <= to).ToList();
    }

    public List<Transaction> FilterByAmount(float min, float max) {
        return _transactions.Where(t => t.PaymentAmount >= min && t.PaymentAmount <= max).ToList();
    }

    public List<Transaction> FilterByDescription(string query) {
        return _transactions.Where(t => t.Description.Contains(query)).ToList();
    }

    public List<Transaction> FilterByCategories(List<Category> categories) {
        List<Transaction> transactions = new List<Transaction>();

        foreach (var iCategory in categories) {
            transactions.AddRange(_transactions.Where(t => t.Category.Name == iCategory.Name).ToList());
        }

        return transactions;
    }
    #endregion

    private void LoadTransactionDataFromJson() {
        IReadOnlyList<Transaction> transactions = _transactionLoader.LoadTransactions();
        
        if (transactions == null) {
            Debug.LogError("TransactionData.json not found or empty");
            return;
        }

        if (transactions.Count() == 0) {
            Debug.LogWarning("List TransactionData in Json-file is empty");
            return;
        }


        AddDownloadedTransactionToList(transactions.ToList());
    }

    private void CreateTransactions(List<TransactionData> data) {
        _transactions = new List<Transaction>();
        
        foreach (var iData in data) {
            Create(iData);
        }
    }

    private void Create(TransactionData transactionData) {
        Guid guid = Guid.NewGuid();

        Transaction newTransaction = new Transaction(transactionData, $"{guid}");
        _transactions.Add(newTransaction);

        SaveTransactions();
    }

    private void Remove(TransactionData transactionData) {
        Transaction transaction = _transactions.FirstOrDefault(transaction => transaction.Data == transactionData);
        _transactions.Remove(transaction);
    }

    private void AddDownloadedTransactionToList(List<Transaction> transactions) {
        foreach (var iTransaction in transactions) {
            _transactions.Add(iTransaction);
        }
    }
}
