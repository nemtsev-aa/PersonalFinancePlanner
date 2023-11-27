using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogSwitcher {
    private RectTransform _dialogsParent;
    private DialogFactory _dialogFactory;
    private Dialog _activeDialog;

    private Dictionary<DialogTypes, Dialog> _dialogsDictionary;
    private DialogSwitcherView _dialogSwitcherView;

    public DialogSwitcher(DialogFactory dialogFactory, RectTransform dialogsParent, DialogSwitcherView dialogSwitcherView) {
        _dialogFactory = dialogFactory;
        _dialogsParent = dialogsParent;

        _dialogFactory.Init(_dialogsParent);

        _dialogSwitcherView = dialogSwitcherView;
        _dialogSwitcherView.ActiveSelectorChanged += OnActiveSelectorChanged;

        CreateDialogs();
    }

    private void CreateDialogs() {
        _dialogsDictionary = new Dictionary<DialogTypes, Dialog> {
            { DialogTypes.DesktopDialog, _dialogFactory.GetDialog<DesktopDialog>(_dialogsParent)},
            { DialogTypes.Transactions, _dialogFactory.GetDialog<TransactionsDialog>(_dialogsParent)},
            { DialogTypes.Category, _dialogFactory.GetDialog<CategoryDialog>(_dialogsParent)},
            { DialogTypes.FinancialGoals, _dialogFactory.GetDialog<FinancialGoalsDialog>(_dialogsParent)},
            { DialogTypes.Settings, _dialogFactory.GetDialog<SettingsDialog>(_dialogsParent)},
            { DialogTypes.About, _dialogFactory.GetDialog<AboutDialog>(_dialogsParent)}
        };

        foreach (var iDialog in _dialogsDictionary.Values) {
            iDialog.Close();
        }
    }

    public Dialog GetDialogByType(DialogTypes type) {
        if (_dialogsDictionary.Keys.Count == 0)
            throw new ArgumentNullException("DialogsDictionary is empty");

        return _dialogsDictionary[type];
    }

    public void ShowDialog(DialogTypes type) {
        if (_activeDialog != null) _activeDialog.Show(false);
        _activeDialog = GetDialogByType(type);

        _activeDialog.Show(true);
    }

    public List<Dialog> GetDialogList() {
        return _dialogsDictionary.Values.ToList();
    }

    public void ShowDialogSwitcherView() => _dialogSwitcherView.Show(true);
    private void OnActiveSelectorChanged(SelectorView selectorView) => ShowDialog(selectorView.Config.Type);

}
