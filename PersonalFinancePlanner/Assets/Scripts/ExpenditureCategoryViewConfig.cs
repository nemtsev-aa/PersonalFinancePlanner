using System;
using UnityEngine;

[Serializable]
public class ExpenditureCategoryViewConfig : CategoryViewConfig {
    public event Action ExpenditureDataChanged;

    public ExpenditureCategoryViewConfig(string name, Sprite icon) : base(name, icon) {
    }

    [field: SerializeField] public float Limit { get; private set; }
    
    public override void OnValidate() {
        if (Limit == 0)
            throw new ArgumentNullException("Limit is empty");
    }

    public override Category GetCategory() {
        CategoryData data = new CategoryData(Name, Icon, Limit, Value);
        return new Category(data);
    }

    public override void SetCategoryData(CategoryData data) {
        Name = data.Name;
        Icon = data.Icon;
        Limit = data.Limit;
        Value = data.Value;

        ExpenditureDataChanged?.Invoke();
    }
}
