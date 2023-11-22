using UnityEngine;
using System;

[Serializable]
public class DialogSwitcherViewConfig : UICompanentConfig {
    [field: SerializeField] public Color BackgroundColor { get; private set; }
    [field: SerializeField] public Sprite Frame { get; private set; }
    public SelectorViewConfigs Configs { get; private set; }
    
    public override void OnValidate() {
        if (BackgroundColor == Color.clear)
            throw new ArgumentNullException($"{BackgroundColor}: is null");

        if (Frame == null)
            throw new ArgumentNullException($"{Frame}: is null");
    }

    public void Init(SelectorViewConfigs configs) {
        Configs = configs;
    }
}
