using UnityEngine;

public class CategoryViewConfig : UICompanentConfig {
    public CategoryViewConfig(string name, Sprite icon) {
        Name = name;
        Icon = icon;
    }

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }

    public override void OnValidate() {
        
    }
}
