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

    private CategoryData _category;
    private CategoryView _categoryView;

    private TransactionData _data;
    private List<TransactionData> _transactions = new List<TransactionData>();

    public void Init(DialogMediator mediator) {
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

    public override void RemoveListeners() {
        _applayButton.onClick.RemoveListener(CreateTransaction);
        _clearButton.onClick.RemoveListener(ClearFields);
        _categorySelectionView.SelectCategory -= CreateCategoryViewPanel;
    }

    public void SetTransactionData(TransactionData data) {
        _data = data;
        FillInFields();
    }

    public void SetCategoryData(CategoryData categoryData) {
        _category = categoryData;
        _categorySelectionView.SetCategoryData(_category);
    }

    public void SetCategoryView(CategoryView categoryView) {
        _categoryView = categoryView;
        _category = categoryView.Config.GetCategory().CategoryData;

        _categorySelectionView.SetCategoryData(_category);
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

            ClearFields();
            TransactionDataCreated?.Invoke(newTransactionData);
        }
    }

    private void ClearFields() {
        _dateView.Reset();
        _amountInputView.Reset();
        _descriptionInputView.Reset();

        _category = null;
    }

    private void FillInFields() {
        _dateView.SetDate(_data.Date);
        _amountInputView.SetValue($"{_data.Amount}");
        _descriptionInputView.SetValue($"{_data.Description}");

        SetCategoryData(_data.Category.CategoryData);
    }
}
