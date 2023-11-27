using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum FilterTypes {
    Dates,
    Description,
    Amounts,
    IncomeCategory,
    ExpenditureCategory
}

public class FilterPanel : UIPanel {
    public event Action<IReadOnlyList<Transaction>> FilterSelected;

    [SerializeField] private TMP_Dropdown _filterDropdown;
    [Space(10)]
    [SerializeField] private RectTransform _dateParent;
    [SerializeField] private DateView _startDateView;
    [SerializeField] private DateView _endDateView;
    [Space(10)]
    [SerializeField] private RectTransform _descriptionParent;
    [SerializeField] private InputFieldView _description;
    [Space(10)]
    [SerializeField] private RectTransform _amountParent;
    [SerializeField] private InputFieldView _minAmount;
    [SerializeField] private InputFieldView _maxAmount;
    [Space(10)]
    [SerializeField] private RectTransform _incomeCategotyParent;
    [SerializeField] private CategoryViewSelector _incomeCategorySelector;
    [Space(10)]
    [SerializeField] private RectTransform _expenditureCategotyParent;
    [SerializeField] private CategoryViewSelector _expenditureCategorySelector;

    [Space(10)]
    [SerializeField] private Button _applyFilterButton;

    private RectTransform _activeParent;
    private FilterTypes _currentType;
    private TransactionManager _transactionManager;
    private List<Category> _categories = new List<Category>();

    public void Init(TransactionManager transactionManager) {
        _transactionManager = transactionManager;
        _activeParent = _dateParent;

        InitializationCompanents();
        AddListeners();
    }

    public override void AddListeners() {
        _filterDropdown.onValueChanged.AddListener(FilterDropdownValueChanged);
        _applyFilterButton.onClick.AddListener(ApplyButtonClick);
        _incomeCategorySelector.CategorySelected += OnCategorySelected;
        _expenditureCategorySelector.CategorySelected += OnCategorySelected;
    }

    public override void RemoveListeners() {
        _filterDropdown.onValueChanged.RemoveListener(FilterDropdownValueChanged);
        _applyFilterButton.onClick.RemoveListener(ApplyButtonClick);
        _incomeCategorySelector.CategorySelected -= OnCategorySelected;
        _expenditureCategorySelector.CategorySelected -= OnCategorySelected;
    }

    private void InitializationCompanents() {
        _startDateView.Init();
        _endDateView.Init();

        _description.Init();
        _minAmount.Init();
        _maxAmount.Init();

        _incomeCategorySelector.Init();
        _expenditureCategorySelector.Init();

        FilterDropdownValueChanged(0);
    }

    private void FilterDropdownValueChanged(int value) {
        switch (value) {
            case 0:
                ActivateParent(_dateParent);
                _currentType = FilterTypes.Dates;
                break;

            case 1:
                ActivateParent(_amountParent);
                _currentType = FilterTypes.Amounts;
                break;

            case 2:
                ActivateParent(_descriptionParent);
                _currentType = FilterTypes.Description;

                break;

            case 3:
                ActivateParent(_incomeCategotyParent);
                _currentType = FilterTypes.IncomeCategory;
                break;

            case 4:
                ActivateParent(_expenditureCategotyParent);
                _currentType = FilterTypes.ExpenditureCategory;
                break;

            default:
                break;
        }
    }

    private void ActivateParent(RectTransform parent) {
        _activeParent.gameObject.SetActive(false);
        _activeParent = parent;

        _activeParent.gameObject.SetActive(true);
    }

    private void OnCategorySelected(List<Category> categories) {
        _categories = categories;
        ApplyButtonClick();
    }

    private void ApplyButtonClick() {
        GetFilteredList();
        gameObject.SetActive(false);
    }

    private void GetFilteredList() {
        List<Transaction> filteredList = new List<Transaction>();

        switch (_currentType) {
            case FilterTypes.Dates:
                filteredList = _transactionManager.FilterByDate(_startDateView.CurrentDate, _endDateView.CurrentDate);

                break;

            case FilterTypes.Description:
                filteredList = _transactionManager.FilterByDescription(_description.GetValue());
                break;

            case FilterTypes.Amounts:
                filteredList = _transactionManager.FilterByAmount(float.Parse(_minAmount.GetValue()), float.Parse(_maxAmount.GetValue())); 
                break;

            case FilterTypes.IncomeCategory:
                filteredList = _transactionManager.FilterByCategories(_categories);

                break;

            case FilterTypes.ExpenditureCategory:
                filteredList = _transactionManager.FilterByCategories(_categories);

                break;

            default:
                break;
        }

        FilterSelected?.Invoke(filteredList);
    }
}
