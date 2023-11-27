using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutDialog : Dialog {

    public override void Init(DialogMediator mediator) {
        base.Init(mediator);

        IsInit = true;
    }

    public override void AddListeners() {
        base.AddListeners();
    }

    public override void RemoveListeners() {
        base.RemoveListeners();
    }
}
