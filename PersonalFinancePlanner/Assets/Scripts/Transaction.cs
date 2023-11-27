using Newtonsoft.Json;
using System;
using UnityEngine;

[Serializable]
public class Transaction {
    public Transaction(TransactionData transactionData, string id) {
        Data = transactionData;

        ID = id;
        Date = Data.Date;
        Description = Data.Description;
        PaymentAmount = Data.Amount;
        Category = Data.Category;
    }

    [JsonConstructor]
    public Transaction(string id, DateTime date, string description, float paymentAmount, Category category, TransactionData data) {
        ID = id;
        Date = date;
        Description = description;
        PaymentAmount = paymentAmount;
        Category = category;
        Data = data;
    }

    public string ID { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public float PaymentAmount { get; private set; }
    public Category Category { get; private set; }

    public TransactionData Data { get; private set; }
    
    public override string ToString() {
        return string.Format($"Описание: {Data.Description}, Сумма: {Data.Amount}, Категория: {Data.Category.CategoryData.Name}");
    }
}
