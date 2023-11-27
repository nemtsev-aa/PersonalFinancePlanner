using System;
using Newtonsoft.Json;

[Serializable]
public class Category {
    [JsonConstructor]
    public Category(string name, float limit, float currentExpense, CategoryData categoryData) {
        Name = name;
        Limit = limit;
        CurrentExpense = currentExpense;
        CategoryData = categoryData;
    }

    public Category(CategoryData categoryData) {
        Name = categoryData.Name;
        Limit = categoryData.Limit;
        CurrentExpense = categoryData.CurrentExpense;

        CategoryData = categoryData;
    }

    public string Name { get; private set; }
    public float Limit { get; private set; }
    public float CurrentExpense { get; private set; }
    public CategoryData CategoryData { get; private set; }

    public override string ToString() {
        return string.Format($"Описание: {CategoryData.Name}, Лимит: {CategoryData.Limit}, Значение: {CategoryData.CurrentExpense}");
    }
}
