using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatorTransactionPanel : MonoBehaviour, IDisposable {
    [SerializeField] private TMP_Dropdown _categoryDropdown;
    [SerializeField] private TMP_InputField _descriptionInputField;
    [SerializeField] private TMP_InputField _amountInputField;

    [SerializeField] private Button _applayButton;
    [SerializeField] private Button _clearButton;

    [SerializeField] private TextMeshProUGUI _infoText;
    
    private IncomeCategoryViewConfigs _configs;
    private Category _category;
    private List<TransactionData> _transactionDatas;

    public IEnumerable<TransactionData> TransactionDatas => _transactionDatas;


    public void Init(IncomeCategoryViewConfigs configs) {
        _configs = configs;

        _transactionDatas = new List<TransactionData>();

        CreateDropDownList();
        CreateSubscribers();
    }

    private void CreateDropDownList() {
        TMP_Dropdown.OptionData optionData;
        List<TMP_Dropdown.OptionData> dropdownData = new List<TMP_Dropdown.OptionData>();

        foreach (var iConfig in _configs.Configs) {
            optionData = new TMP_Dropdown.OptionData(iConfig.Name, iConfig.Icon);
            dropdownData.Add(optionData);
        }

        _categoryDropdown.AddOptions(dropdownData);
    }

    private void CreateSubscribers() {
        _applayButton.onClick.AddListener(CreateTransaction);
        _clearButton.onClick.AddListener(ClearFields);
        _categoryDropdown.onValueChanged.AddListener(SetCategory);
    }

    private void SetCategory(int index) {
        TMP_Dropdown.OptionData optionData = _categoryDropdown.options[index];
        _category = new Category(optionData.text, optionData.image);
    }

    private void CreateTransaction() {
        SetCategory(_categoryDropdown.value);
        TransactionData newTransactionData = new TransactionData(_descriptionInputField.text, float.Parse(_amountInputField.text), _category);
        
        _transactionDatas.Add(newTransactionData);
    }

    private void ClearFields() {
        _descriptionInputField.text = "";
        _amountInputField.text = "";
        _category = null;
    }

    public void Dispose() {
        _applayButton.onClick.RemoveListener(CreateTransaction);
        _clearButton.onClick.RemoveListener(ClearFields);
        _categoryDropdown.onValueChanged.RemoveListener(SetCategory);
    }
}
