using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IDisposable {
    [SerializeField] private SelectorViewConfigs _selectorViewConfigs;
    [SerializeField] private DialogFactory _dialogFactory;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    [SerializeField] private RectTransform _dialogsParent;
    [SerializeField] private DialogSwitcherView _switcherView;

    private DialogSwitcher _dialogSwitcher;
    private List<Dialog> _dialogs;

    private void Start() {
        _switcherView.Init(_selectorViewConfigs, _companentsFactory);
        _dialogSwitcher = new DialogSwitcher(_dialogFactory, _dialogsParent, _switcherView);
        _dialogs = _dialogSwitcher.GetDialogList();
        
        AddListeners();
    }

    private void AddListeners() {
        foreach (var iDialog in _dialogs) {
            iDialog.ShowDialogSwitcherSelected += OnShowDialogSwitcherSelected;
        }

        _dialogSwitcher.GetDialogByType(DialogTypes.DesktopDialog).TryGetComponent(out DesktopDialog desktop);
        _dialogSwitcher.GetDialogByType(DialogTypes.Transactions).TryGetComponent(out TransactionsDialog transactions);

        desktop.IncomeTransactionSelected += () => _dialogSwitcher.ShowDialog(DialogTypes.Category);
        desktop.IncomeTransactionSelected += () => transactions.ShowCreatorTransaction(true);

    }

    private void OnShowDialogSwitcherSelected() {
        _switcherView.Show(true);
    }

    public void ShowTransactionCreatorPanel() {

    }

    public void Dispose() {
        foreach (var iDialog in _dialogs) {
            iDialog.ShowDialogSwitcherSelected -= OnShowDialogSwitcherSelected;
        }
    }
}
