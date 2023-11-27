using System;
using UnityEngine;

[Serializable]
public class IconVariantViewConfig : UICompanentConfig {
    public IconVariantViewConfig(Sprite icon) {
        Icon = icon;
    }

    [field: SerializeField] public Sprite Icon { get; private set; }

    public override void OnValidate() {
        
    }
}
