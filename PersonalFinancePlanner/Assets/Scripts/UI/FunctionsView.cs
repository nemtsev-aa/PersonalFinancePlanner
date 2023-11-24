using QuantumTek.QuantumUI;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FunctionsView : UICompanent, IDisposable {
    public event Action CreateTransaction;
    public event Action EditCategory;

    [SerializeField] private Button _createTransaction;
    [SerializeField] private Button _editCategory;
    [SerializeField] private QUI_SwitchToggle _switchToggle;

    public void Init() {
        AddListeners();

        SwitchToggleClick(_switchToggle.toggle.isOn);
    }

    private void AddListeners() {
        _createTransaction.onClick.AddListener(CreateTransactionClick);
        _editCategory.onClick.AddListener(EditCategoryClick);
        _switchToggle.toggle.onValueChanged.AddListener(SwitchToggleClick);
    }

    private void CreateTransactionClick() => CreateTransaction?.Invoke();

    private void EditCategoryClick() => EditCategory?.Invoke();

    private void SwitchToggleClick(bool value) {
        if (value) {
            _createTransaction.interactable = true;
            _editCategory.interactable = false;
        } 
        else 
        {
            _createTransaction.interactable = false;
            _editCategory.interactable = true;
        }
    }

    public void Dispose() {
        _createTransaction.onClick.RemoveListener(CreateTransactionClick);
        _editCategory.onClick.RemoveListener(EditCategoryClick);
        _switchToggle.toggle.onValueChanged.RemoveListener(SwitchToggleClick);
    }
}
