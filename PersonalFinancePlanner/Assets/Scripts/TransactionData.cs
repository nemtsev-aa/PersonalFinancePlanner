using System;
using UnityEngine;

[Serializable]
public class TransactionData {
    public TransactionData(string description, float amount, Category category) {
        Description = description;
        Amount = amount;
        Category = category;
    }

    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public float Amount { get; private set; }
    [field: SerializeField] public Category Category { get; private set; }

    public void SetCategory(Category category) {
        Category = category;
    }
}
