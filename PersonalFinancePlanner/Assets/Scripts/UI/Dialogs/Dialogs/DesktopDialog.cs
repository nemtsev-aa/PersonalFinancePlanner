using System;
using UnityEngine;

public class DesktopDialog : Dialog {
    public event Action<CategoryViewConfig> EditCategory;

    public event Action<IncomeCategoryViewConfig, DateTime> CreateIncomeTransaction;
    public event Action<ExpenditureCategoryViewConfig, DateTime> CreateExpenditureTransaction;

    [SerializeField] private DateView _dateView;
    [SerializeField] private FunctionsView _functionsView;
    [SerializeField] private CategoryWidgetPanels _categoryWidgetsPanel;

    private IncomeCategoryViewConfig _incomeConfig;
    private ExpenditureCategoryViewConfig _expenditureConfig;

    public override void Init() {
        if (IsInit == true)
            return;

        base.Init();

        _dateView.Init();
        _functionsView.Init();
        _categoryWidgetsPanel.Init();

        IsInit = true;
    }

    public override void AddListeners() {
        base.AddListeners();

        _functionsView.EditCategory += OnEditCategory;
        _functionsView.CreateTransaction += OnCreateTransaction;

        _categoryWidgetsPanel.IncomeWidgetSelected += OnIncomeWidgetSelected;
        _categoryWidgetsPanel.ExpenditureWidgetSelected += OnExpenditureWidgetSelected;
    }

    private void OnCreateTransaction() {
        Debug.Log($"OnCreateTransaction");

        if (_incomeConfig != null)
            CreateIncomeTransaction?.Invoke(_incomeConfig, _dateView.CurrentDate);
        else
            CreateExpenditureTransaction?.Invoke(_expenditureConfig, _dateView.CurrentDate);
    }

    private void OnEditCategory() {
        Debug.Log($"OnEditCategory");

        if (_incomeConfig != null)
            EditCategory?.Invoke(_incomeConfig);
        else
            EditCategory?.Invoke(_expenditureConfig);
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _functionsView.EditCategory -= OnEditCategory;
        _functionsView.CreateTransaction -= OnCreateTransaction;

        _categoryWidgetsPanel.IncomeWidgetSelected -= OnIncomeWidgetSelected;
        _categoryWidgetsPanel.ExpenditureWidgetSelected -= OnExpenditureWidgetSelected;
    }

    private void OnIncomeWidgetSelected(IncomeCategoryViewConfig config) {
        _incomeConfig = config;
        _expenditureConfig = null;
    }

    private void OnExpenditureWidgetSelected(ExpenditureCategoryViewConfig config) {
        _incomeConfig = null;
        _expenditureConfig = config;
    }
}
