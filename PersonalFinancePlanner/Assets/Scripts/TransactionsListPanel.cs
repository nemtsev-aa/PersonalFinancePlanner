using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransactionsListPanel : UIPanel {
    public event Action<Transaction> EditTransaction;
    public event Action ShowFilterPanel;

    [SerializeField] private RectTransform _transactionViewParent;
    [SerializeField] private ToggleGroup _group;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    [SerializeField] private TextMeshProUGUI _transactionsCountText;
    [SerializeField] private Button _editTransaction;
    [SerializeField] private Button _clearTransaction;
    [SerializeField] private Button _showFilter;

    private TransactionManager _transactionManager;
    private List<TransactionView> _transactionViews;

    private TransactionView _selectedTransactionView;

    public void Init(TransactionManager transactionManager, DialogMediator dialogMediator) {
        _transactionManager = transactionManager;
        _transactionViews = new List<TransactionView>();
        
        AddListeners();
        SetTransactionsList(_transactionManager.Transactions);
    }

    public override void AddListeners() {
        _editTransaction.onClick.AddListener(EditTransactionClick);
        _clearTransaction.onClick.AddListener(CleartTransactionClick);
        _showFilter.onClick.AddListener(ShowFilterPanelClick);
    }

    public override void UpdateContent() {
        base.UpdateContent();

        SetTransactionsList(_transactionManager.Transactions);
    }

    public void SetTransactionsList(IReadOnlyList<Transaction> transactions) {
        ClearTransactionViews();

        if (transactions.Count == 0) {
            ShowTransactionsCount();
            return;
        }
           
        CreateTransactionViews(transactions);
    }

    public override void RemoveListeners() {
        _editTransaction.onClick.RemoveListener(EditTransactionClick);
        _clearTransaction.onClick.RemoveListener(CleartTransactionClick);
    }

    private void EditTransactionClick() => EditTransaction?.Invoke(_selectedTransactionView.Config.Transaction);

    private void CleartTransactionClick() => ClearTransactionView();

    private void CreateTransactionViews(IReadOnlyList<Transaction> transactions) {
        foreach (var iTransaction in transactions) {
            var iConfig = new TransactionViewConfig(iTransaction.Data);

            TransactionView newTransactionView = _companentsFactory.Get<TransactionView>(iConfig, _transactionViewParent);
            newTransactionView.Init(iConfig);
            newTransactionView.Toggle.group = _group;
            newTransactionView.TransactionViewSelected += OnTransactionViewSelected;

            _transactionViews.Add(newTransactionView);
        }

        ShowTransactionsCount();
    }

    private void ClearTransactionViews() {
        if (_transactionViewParent.childCount == 0)
            return;

        foreach (RectTransform iTransform in _transactionViewParent) {
            Destroy(iTransform.gameObject);
        }

        _transactionViews.Clear();
    }

    private void ClearTransactionView() {
        if (_selectedTransactionView == null)
            return;

        Destroy(_selectedTransactionView.gameObject);
        
        _transactionViews.Remove(_selectedTransactionView);
        _transactionManager.RemoveTransaction(_selectedTransactionView.Config.Transaction.Data);
        
        ShowTransactionsCount();
    }

    private void ShowTransactionsCount() {
        _transactionsCountText.text = $"{_transactionViews.Count}";
    }

    private void ShowFilterPanelClick() => ShowFilterPanel?.Invoke();

    private void OnTransactionViewSelected(TransactionView view) {
        _selectedTransactionView = view;
    }
}
