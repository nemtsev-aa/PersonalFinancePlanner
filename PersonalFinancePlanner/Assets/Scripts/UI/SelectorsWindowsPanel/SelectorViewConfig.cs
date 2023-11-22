using System;
using UnityEngine;

[Serializable]
public class SelectorViewConfig : UICompanentConfig {
    [field: SerializeField] public DialogTypes Type { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }

    public override void OnValidate() {
        if (Name == null)
            throw new ArgumentNullException($"{Name}: is null");

        if (Icon == null)
            throw new ArgumentNullException($"{Icon}: is null");
    }
}
