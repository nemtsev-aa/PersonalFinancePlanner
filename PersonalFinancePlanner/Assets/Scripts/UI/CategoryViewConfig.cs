using UnityEngine;
using System;

public abstract class CategoryViewConfig : UICompanentConfig {
    public CategoryViewConfig(string name, Sprite icon) {
        Name = name;
        Icon = icon;
    }

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public float Value { get; private set; }

    public override void OnValidate() {
        if (Name == null)
            throw new ArgumentNullException("Name is empty");

        if (Icon == null)
            throw new ArgumentNullException("Icon is empty");

        if (Value < 0)
            throw new ArgumentNullException("Value is empty");
    }

    public abstract Category GetCategory();
}
