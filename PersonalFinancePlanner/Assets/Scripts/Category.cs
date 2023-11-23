using UnityEngine;

public class Category {
    public CategoryData CategoryData { get; private set; }

    public Category(CategoryData categoryData) {
        CategoryData = categoryData;
    }
    public override string ToString() {
        return string.Format($"��������: {CategoryData.Name}, �����: {CategoryData.Limit}, ��������: {CategoryData.Value}");
    }
}
