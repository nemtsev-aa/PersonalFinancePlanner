using UnityEngine;

public class CategoryData {
    public CategoryData(string name, Sprite icon, float limit, float value) {
        Name = name;
        Icon = icon;
        Limit = limit;
        Value = value;
    }

    public string Name { get; private set; }
    public Sprite Icon { get; private set; }
    public float Limit { get; private set; }
    public float Value { get; private set; }
}
