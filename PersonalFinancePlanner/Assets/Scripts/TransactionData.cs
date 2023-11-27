using Newtonsoft.Json;
using System;
using UnityEngine;

[Serializable]
public class TransactionData {
    public TransactionData(DateTime date, Category category) {
        Date = date;
        Category = category;
    }

    [JsonConstructor]
    public TransactionData(DateTime date, string description, float amount, Category category) {
        Date = date;
        Description = description;
        Amount = amount;
        Category = category;
    }

    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public float Amount { get; private set; }
    public Category Category { get; private set; }

    public void SetParameters(TransactionData data) {
        Date = data.Date;
        Description = data.Description;
        Amount = data.Amount;
        Category = data.Category;
    }
}
