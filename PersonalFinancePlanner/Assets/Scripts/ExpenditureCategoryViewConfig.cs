using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class ExpenditureCategoryViewConfig : CategoryViewConfig {
    public ExpenditureCategoryViewConfig(string name, Sprite icon) : base(name, icon) {
    }

    public override void OnValidate() {

    }
}
