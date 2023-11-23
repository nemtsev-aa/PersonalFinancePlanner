using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatorTransactionPanel : UIPanel {
    public event Action ShowCategorySelectionPanel;

    [SerializeField] private DateView _dateView;
    [SerializeField] private InputFieldView _amountInputView;
    [SerializeField] private InputFieldView _descriptionInputView;
    [SerializeField] private CategorySelectionView _categorySelectionView;

    [SerializeField] private Button _applayButton;
    [SerializeField] private Button _clearButton;

    [SerializeField] private TextMeshProUGUI _infoText;


    private CategoryViewConfig _category;
    private List<TransactionData> _transactionDatas;
    private TransactionData _data;

    public IEnumerable<TransactionData> TransactionDatas => _transactionDatas;

    public override void Init() {
        base.Init();
        _transactionDatas = new List<TransactionData>();

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
        Category category = _category.GetCategory();
        //TransactionData newTransactionData = new TransactionData(_descriptionInputView.Value, float.Parse(_amountInputView.Value), category);

        //_transactionDatas.Add(newTransactionData);
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
