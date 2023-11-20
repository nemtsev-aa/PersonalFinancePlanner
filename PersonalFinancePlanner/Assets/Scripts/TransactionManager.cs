using System;
using System.Collections.Generic;
using UnityEngine;

public class TransactionManager : MonoBehaviour {
    [SerializeField] private string _categoryName;
    [SerializeField] private string _transactionName;
    [SerializeField] private float _amount;

    [field: SerializeField] public CategoryConfigs CategoryConfigs { get; private set; }
    [field: SerializeField] public List<Transaction> Transactions { get; private set; }

    private void Start() {
        Transactions = new List<Transaction>();
    }

    [ContextMenu("CreateTransitions")]
    public void CreateTransitions() {
        CreateTransaction(_categoryName, _transactionName, _amount);
        DisplayTransactions();
    }

    private void CreateTransaction(string categoryName, string transactionName, float amount) {
        Category category;
        category = new Category(categoryName, CategoryConfigs.GetSpriteByCategoryName(categoryName));
        
        Transactions.Add(new Transaction(transactionName, amount, category));
    }

    private void DisplayTransactions() {
        foreach (Transaction transaction in Transactions) {
            Debug.Log(transaction.ToString());
        }
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
