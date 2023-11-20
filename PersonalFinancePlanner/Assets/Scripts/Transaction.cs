using UnityEngine;

public class Transaction {
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public float Amount { get; private set; }
    [field: SerializeField] public Category Category { get; private set; }

    public Transaction(string description, float amount, Category category) {
        Description = description;
        Amount = amount;
        Category = category;
    }

    public void SetCategory(Category category) {
        Category = category;
    }

    public override string ToString() {
        return string.Format($"Описание: {Description}, Сумма: {Amount}, Категория: {Category.Name}");
    }
}
