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
    private DialogMediator _dialogMediator;

    public override void Init(DialogMediator mediator) {
        if (IsInit == true)
            return;

        base.Init(mediator);
        _dialogMediator = mediator;

        _dateView.Init();
        _functionsView.Init();
        _categoryWidgetsPanel.Init();

        IsInit = true;
        UpdateWidgets();
    }

    public override void AddListeners() {
        base.AddListeners();

        _functionsView.EditCategory += OnEditCategory;
        _functionsView.CreateTransaction += OnCreateTransaction;

        _categoryWidgetsPanel.IncomeWidgetSelected += OnIncomeWidgetSelected;
        _categoryWidgetsPanel.ExpenditureWidgetSelected += OnExpenditureWidgetSelected;
    }

    public void UpdateWidgets() => _dialogMediator.UpdateCategories();

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

    private void OnIncomeWidgetSelected(IncomeCategoryViewConfig config) {
        _incomeConfig = config;
        _expenditureConfig = null;
    }

    private void OnExpenditureWidgetSelected(ExpenditureCategoryViewConfig config) {
        _incomeConfig = null;
        _expenditureConfig = config;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _functionsView.EditCategory -= OnEditCategory;
        _functionsView.CreateTransaction -= OnCreateTransaction;

        _categoryWidgetsPanel.IncomeWidgetSelected -= OnIncomeWidgetSelected;
        _categoryWidgetsPanel.ExpenditureWidgetSelected -= OnExpenditureWidgetSelected;
    }
}
