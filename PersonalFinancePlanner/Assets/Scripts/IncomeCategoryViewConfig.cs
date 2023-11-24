using UnityEngine;
using System;

[Serializable]
public class IncomeCategoryViewConfig : CategoryViewConfig {
    public event Action IncomeDataChanged;

    public IncomeCategoryViewConfig(string name, Sprite icon) : base(name, icon) {
    }

    [field: SerializeField] public float Target { get; private set; }
    
    public override void OnValidate() {
        if (Target == 0)
            throw new ArgumentNullException("Target is empty");
    }

    public override Category GetCategory() {
        CategoryData data = new CategoryData(Name, Icon, Target, Value);
        return new Category(data);
    }

    public override void SetCategoryData(CategoryData data) {
        Name = data.Name;
        Icon = data.Icon;
        Target = data.Limit;
        Value = data.Value;

        IncomeDataChanged?.Invoke();
    }
}
