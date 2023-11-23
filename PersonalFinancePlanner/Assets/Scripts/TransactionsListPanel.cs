using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransactionsListPanel : UIPanel {
    public event Action<Transaction> EditTransaction;

    [SerializeField] private RectTransform _transactionViewParent;
    [SerializeField] private UICompanentsFactory _companentsFactory;
    [SerializeField] private Button _editTransaction;
    [SerializeField] private Button _clearTransaction;

    private List<TransactionViewConfig> _transactionViewConfigs;
    private List<TransactionView> _transactionViews;

    private TransactionView _selectedTransactionView;

    public void Init(List<TransactionViewConfig> transactionViewConfigs) {
        _transactionViewConfigs = transactionViewConfigs;

        _transactionViews = new List<TransactionView>();
        CreateTransactionViews();
    }


    public override void AddListeners() {
        _editTransaction.onClick.AddListener(EditTransactionClick);
        _clearTransaction.onClick.AddListener(CleartTransactionClick);
    }


    public override void RemoveListeners() {
        _editTransaction.onClick.RemoveListener(EditTransactionClick);
        _clearTransaction.onClick.RemoveListener(CleartTransactionClick);
    }

    private void EditTransactionClick() => EditTransaction?.Invoke(_selectedTransactionView.Config.Transaction);

    private void CleartTransactionClick() => ClearTransactionView();

    private void CreateTransactionViews() {
        ClearTransactionViews();

        foreach (var iConfig in _transactionViewConfigs) {
            TransactionView newTransactionView = _companentsFactory.Get<TransactionView>(iConfig, _transactionViewParent);
            newTransactionView.Init(iConfig);

            _transactionViews.Add(newTransactionView);
        }
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
        if (_selectedTransactionView = null)
            return;

        Destroy(_selectedTransactionView.gameObject);
        _transactionViews.Remove(_selectedTransactionView);
    }
}
