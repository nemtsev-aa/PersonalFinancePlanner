using System;
using UnityEngine;
using UnityEngine.UI;

public class DesktopDialog : Dialog {
    public event Action IncomeTransactionSelected;
    public event Action ExpenditureTransactionSelected;

    [SerializeField] private DateView _dateView;
    [SerializeField] private CategoryWidgetPanels _categoryWidgetsPanel;
    
    [SerializeField] private Button _incomeTransaction;
    [SerializeField] private Button _expenditureTransaction;
   
    public override void Init() {
        if (IsInit == true)
            return;

        base.Init();

        _dateView.Init();
        _categoryWidgetsPanel.Init();

        IsInit = true;
    }

    public override void AddListeners() {
        base.AddListeners();
        _incomeTransaction.onClick.AddListener(IncomeTransactionClick);
        _expenditureTransaction.onClick.AddListener(ExpenditureTransactionClick);

        //_categoryWidgetsPanel.IncomeWidgetSelected += 
    }

    public override void RemoveListeners() {
        base.RemoveListeners();
        _incomeTransaction.onClick.RemoveListener(IncomeTransactionClick);
        _expenditureTransaction.onClick.RemoveListener(ExpenditureTransactionClick);
    }

    private void IncomeTransactionClick() => IncomeTransactionSelected?.Invoke();
    private void ExpenditureTransactionClick() => ExpenditureTransactionSelected?.Invoke();
   
}
