using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatorTransactionPanel : UIPanel {
    public event Action ShowCategorySelectionPanel;
    public event Action<TransactionData> TransactionDataCreated;

    [SerializeField] private DateView _dateView;
    [SerializeField] private InputFieldView _amountInputView;
    [SerializeField] private InputFieldView _descriptionInputView;
    [SerializeField] private CategorySelectionView _categorySelectionView;

    [SerializeField] private Button _applayButton;
    [SerializeField] private Button _clearButton;

    [SerializeField] private TextMeshProUGUI _infoText;

    private CategoryViewConfig _category;
    private TransactionData _data;
    private List<TransactionData> _transactions = new List<TransactionData>();

    public override void Init() {
        base.Init();
 
        AddListeners();
        InitializationViews();
    }

    private void InitializationViews() {
        _dateView.Init();
        _amountInputView.Init();
        _descriptionInputView.Init();
        _categorySelectionView.Init();
    }

    public override void AddListeners() {
        _applayButton.onClick.AddListener(CreateTransaction);
        _clearButton.onClick.AddListener(ClearFields);
        _categorySelectionView.SelectCategory += CreateCategoryViewPanel;
    }

    public void SetTransactionData(TransactionData data) {
        _data = data;
        FillInFields();
    }

    private void FillInFields() {
        _dateView.SetDate(_data.Date);
        _amountInputView.SetValue($"{_data.Amount}");
        _descriptionInputView.SetValue($"{_data.Description}");
    }

    public void SetCategoryView(CategoryView categoryView) {
        _category = categoryView.Config;
        categoryView.gameObject.transform.SetParent(_categorySelectionView.CategoryViewContainer, false);
        categoryView.GetComponent<RectTransform>().localScale = Vector3.one * 2;

        _categorySelectionView.ShowCategoryView();
    }

    private void CreateCategoryViewPanel() => ShowCategorySelectionPanel?.Invoke();

    private void CreateTransaction() {
        DateTime date = _dateView.CurrentDate;
        string description = _descriptionInputView.Value.ToString();
        float amount = float.Parse(_amountInputView.Value);
        Category category = _data.Category;

        TransactionData newTransactionData = new TransactionData(date, description, amount, category);

        if (newTransactionData != _transactions.FirstOrDefault(transition => transition.Date == _data.Date)) {
            category.CategoryData.SetValue(amount);
            _transactions.Add(newTransactionData);
            TransactionDataCreated?.Invoke(newTransactionData);
        }
    }

    private void ClearFields() {
        _dateView.Reset();
        _amountInputView.Reset();
        _descriptionInputView.Reset();

        _category = null;
    }

    public override void RemoveListeners() {
        _applayButton.onClick.RemoveListener(CreateTransaction);
        _clearButton.onClick.RemoveListener(ClearFields);
    }
}
