using UnityEngine;
using System;

[Serializable]
public class IncomeCategoryViewConfig : CategoryViewConfig {
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
}
