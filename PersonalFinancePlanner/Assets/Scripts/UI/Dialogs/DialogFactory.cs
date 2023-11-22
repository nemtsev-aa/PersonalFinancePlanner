using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogFactory", menuName = "Factory/DialogFactory")]
public class DialogFactory : ScriptableObject {
    private const string PrefabsFilePath = "Dialogs/";
    
    private RectTransform _dialogsParent;
    private Dictionary<DialogTypes, Dialog> _dialogsDictionary;

    private static readonly Dictionary<Type, string> _prefabsDictionary = new Dictionary<Type, string>() {
            {typeof(DesktopDialog),"DesktopDialog"},
            {typeof(TransactionsDialog),"TransactionsDialog"},
            {typeof(CategoryDialog),"CategoryDialog"},
            {typeof(FinancialGoalsDialog),"FinancialGoalsDialog"},
            {typeof(SettingsDialog),"SettingsDialog"},
            {typeof(AboutDialog),"AboutDialog"},
    };

    public void Init(RectTransform dialogsParent) {
        _dialogsParent = dialogsParent;

        CreateDialogs();
    }

    private void CreateDialogs() {
        _dialogsDictionary = new Dictionary<DialogTypes, Dialog> {
            { DialogTypes.DesktopDialog, GetDialog<DesktopDialog>(_dialogsParent)},
            { DialogTypes.Transactions, GetDialog<TransactionsDialog>(_dialogsParent)},
            { DialogTypes.Category, GetDialog<CategoryDialog>(_dialogsParent)},
            { DialogTypes.FinancialGoals, GetDialog<FinancialGoalsDialog>(_dialogsParent)},
            { DialogTypes.Settings, GetDialog<SettingsDialog>(_dialogsParent)},
            { DialogTypes.About, GetDialog<AboutDialog>(_dialogsParent)}
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

    public T GetDialog<T>(RectTransform parent) where T : Dialog {
        var go = GetPrefabByType<T>();

        if (go == null)
            return null;

        return (T)Instantiate<Dialog>(go, parent);
    }

    private T GetPrefabByType<T>() where T : Dialog {
        var prefabName = _prefabsDictionary[typeof(T)];

        if (string.IsNullOrEmpty(prefabName)) {
            Debug.LogError("Cant find prefab type of " + typeof(T) + "Do you added it in PrefabsDictionary?");
        }

        var path = PrefabsFilePath + _prefabsDictionary[typeof(T)];
        var dialog = Resources.Load<T>(path);

        if (dialog == null)
            Debug.LogError("Cant find prefab at path " + path);

        return dialog;
    }
}