using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCategoryPanel : UIPanel {
    public event Action<Category> CategorySelected;

    public override void Init() {
        base.Init();

    }

    public override void AddListeners() {
        
    }

    public override void RemoveListeners() {
        
    }
}
