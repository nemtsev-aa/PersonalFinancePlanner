using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IDisposable {
    private SelectorViewConfigs _selectorViewConfigs;
    private UICompanentsFactory _companentsFactory;
    private DialogSwitcher _dialogSwitcher;
    private DialogMediator _dialogMediator;

    private List<Dialog> _dialogs;
    
    [field: SerializeField] public RectTransform DialogsParent { get; private set; }
    [field: SerializeField] public DialogSwitcherView SwitcherView { get; private set; }
    
    public void Init(SelectorViewConfigs selectorViewConfigs, UICompanentsFactory companentsFactory, DialogSwitcher dialogSwitcher, DialogMediator dialogMedialor) {
        _selectorViewConfigs = selectorViewConfigs;
        _companentsFactory = companentsFactory;
        _dialogSwitcher = dialogSwitcher;
        _dialogMediator = dialogMedialor;

        InitializationCompanents();
        AddListeners();
    }

    private void InitializationCompanents() {       
        _dialogs = _dialogSwitcher.GetDialogList();

        SwitcherView.Init(_selectorViewConfigs, _companentsFactory);
    }

    private void AddListeners() {
        foreach (var iDialog in _dialogs) {
            iDialog.ShowDialogSwitcherSelected += OnShowDialogSwitcherSelected;
        }
    }

    private void OnShowDialogSwitcherSelected() => SwitcherView.Show(true);

    private void RemoveListeners() {
        foreach (var iDialog in _dialogs) {
            iDialog.ShowDialogSwitcherSelected -= OnShowDialogSwitcherSelected;
        }
    }

    public void Dispose() {
        RemoveListeners();
    }
}
