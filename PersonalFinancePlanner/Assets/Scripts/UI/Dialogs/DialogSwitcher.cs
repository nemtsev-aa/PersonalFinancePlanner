using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogSwitcher {
    private RectTransform _dialogsParent;
    private DialogFactory _dialogFactory;
    private List<Dialog> _dialogs;
    private Dialog _activeDialog;

    public DialogSwitcher(DialogFactory dialogFactory, RectTransform dialogsParent) {
        _dialogFactory = dialogFactory;
        _dialogsParent = dialogsParent;

        _dialogFactory.Init(_dialogsParent);
    }

    public void ShowDialog<T>() {
        if (_activeDialog != null) _activeDialog.Show(false);
        _activeDialog = _dialogs.FirstOrDefault(dialog => dialog is T);
        _activeDialog.Show(true);
    }

    public void ShowDialog(DialogTypes type) {
        if (_activeDialog != null) _activeDialog.Show(false);
        _activeDialog = _dialogFactory.GetDialogByType(type);
        _activeDialog.Show(true);
    }
}
