using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogFactory : ScriptableObject {
    private const string PrefabsFilePath = "Dialogs/";

    private static readonly Dictionary<Type, string> _prefabsDictionary = new Dictionary<Type, string>() {
            {typeof(DesktopDialog),"DesktopDialog"},
            {typeof(TransactionsDialog),"TransactionsDialog"},
            {typeof(CategoryDialog),"CategoryDialog"},
            {typeof(FinancialGoalsDialog),"FinancialGoalsDialog"},
            {typeof(SettingsDialog),"SettingsDialog"},
            {typeof(AboutDialog),"AboutDialog"},
        };


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