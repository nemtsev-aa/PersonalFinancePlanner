using System;
using UnityEngine;

public class CategoryWidgetConfig : UICompanentConfig {
    private CategoryViewConfig _categoryConfig;

    public CategoryWidgetConfig(CategoryViewConfig categoryConfig) {
        _categoryConfig = categoryConfig;
    }

    public string Name { get; protected set; }
    public string Value { get; protected set; }
    public Sprite Icon { get; protected set; }
    
    public override void OnValidate() {
        
    }
}
