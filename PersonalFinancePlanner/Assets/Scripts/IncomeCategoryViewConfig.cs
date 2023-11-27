using UnityEngine;
using System;

[Serializable]
public class IncomeCategoryViewConfig : CategoryViewConfig {
    public event Action IncomeDataChanged;

    public IncomeCategoryViewConfig(string name, float target, Sprite icon) : base(name, icon) {
        Name = name;
        Target = target;
        Icon = icon;
        Value = 0;
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
        Value = data.CurrentExpense;

        IncomeDataChanged?.Invoke();
    }

    public override void SetCategoryValue(float value) {
        base.SetCategoryValue(value);

        IncomeDataChanged?.Invoke();
    }
}
