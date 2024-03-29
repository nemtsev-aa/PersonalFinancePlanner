using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldView : UICompanent, IDisposable {
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _clearField;

    public string Value { get; private set; }

    public void Init() {
        AddListeners();
    }

    public void SetValue(string value) {
        Value = value;
        ShowValue();
    }

    public string GetValue() {
        return _inputField.text;
    }

    public void Reset() => ClearFieldClick();

    private void AddListeners() {
        _inputField.onValueChanged.AddListener(InputFieldValueChanged);
        _clearField.onClick.AddListener(ClearFieldClick);
    }

    private void ShowValue() => _inputField.text = Value;
    
    private void InputFieldValueChanged(string value) => Value = value;

    private void ClearFieldClick() {
        Value = "";
        ShowValue();
    } 

    public void Dispose() {
        _inputField.onEndEdit.RemoveListener(InputFieldValueChanged);
        _clearField.onClick.RemoveListener(ClearFieldClick);
    }
}
