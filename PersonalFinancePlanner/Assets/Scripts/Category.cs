using UnityEngine;

public class Category {
    public Category(string name, Sprite icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; private set; }
    public Sprite Icon { get; private set; }
}
