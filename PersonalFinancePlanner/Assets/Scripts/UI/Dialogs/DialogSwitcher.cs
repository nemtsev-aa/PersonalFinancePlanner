using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Question3 {
    public class DialogSwitcher {
        private RectTransform _dialogsParent;
        private DialogFactory _dialogFactory;
        private List<Dialog> _dialogs;
        private Dialog _activeDialog;

        public DialogSwitcher(DialogFactory dialogFactory, RectTransform dialogsParent) {
            _dialogFactory = dialogFactory;
            _dialogsParent = dialogsParent;

            CreateDialogs();
        }

        public void CreateDialogs() {
            _dialogs = new List<Dialog>();

            //_dialogs.Add(_dialogFactory.GetDialog<GameProcessDialog>(_dialogsParent));
            //_dialogs.Add(_dialogFactory.GetDialog<VictoryDialog>(_dialogsParent));

            foreach (var iDialog in _dialogs) {
                iDialog.gameObject.SetActive(false);
            }
        }

        public void ShowDialog<T>() {
            if (_activeDialog != null) _activeDialog.Show(false);
            _activeDialog = _dialogs.FirstOrDefault(dialog => dialog is T);
            _activeDialog.Show(true);
        }

        public T GetDialogByType<T>() where T : Dialog {
            return (T)_dialogs.FirstOrDefault(dialog => dialog is T);
        }
    }
}