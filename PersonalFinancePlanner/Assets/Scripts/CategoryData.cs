using UnityEngine;
using System;

[Serializable]
public class CategoryData {
    public CategoryData(string name, Sprite icon, float limit, float value) {
        Name = name;
        Icon = icon;
        Limit = limit;
        Value = value;
    }

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public float Limit { get; private set; }
    [field: SerializeField] public float Value { get; private set; }

    public void SetValue(float value) {
        if (value <= 0)
            throw new ArgumentNullException($"Invalid Value number");

        Value += value;
    }

    public void SetLimit(float value) {
        if (value <= 0)
            throw new ArgumentNullException($"Invalid Limit number");

        Limit += value;
    }
}
