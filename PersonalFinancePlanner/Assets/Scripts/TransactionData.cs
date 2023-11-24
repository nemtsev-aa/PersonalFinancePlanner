using System;
using UnityEngine;

[Serializable]
public class TransactionData {
    public TransactionData(DateTime date, Category category) {
        Date = date;
        Category = category;
    }

    public TransactionData(DateTime date, string description, float amount, Category category) {
        Date = date;
        Description = description;
        Amount = amount;
        Category = category;
    }

    [field: SerializeField] public DateTime Date { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public float Amount { get; private set; }
    [field: SerializeField] public Category Category { get; private set; }

    public void SetParameters(TransactionData data) {
        Date = data.Date;
        Description = data.Description;
        Amount = data.Amount;
        Category = data.Category;
    }
}
