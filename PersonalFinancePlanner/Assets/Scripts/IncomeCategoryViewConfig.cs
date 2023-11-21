using UnityEngine;
using System;

[Serializable]
public class IncomeCategoryViewConfig : CategoryViewConfig {
    public IncomeCategoryViewConfig(string name, Sprite icon) : base(name, icon) {
    }

    public override void OnValidate() {
        
    }
}
