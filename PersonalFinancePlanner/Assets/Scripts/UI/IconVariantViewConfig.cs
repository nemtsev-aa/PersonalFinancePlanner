using System;
using UnityEngine;

[Serializable]
public class IconVariantViewConfig : UICompanentConfig {
    [field: SerializeField] public Sprite Icon { get; private set; }

    public override void OnValidate() {
        
    }
}
