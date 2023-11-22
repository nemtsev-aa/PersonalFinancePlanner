using System;
using System.Collections.Generic;
using UnityEngine;

public class TransactionsListPanel : MonoBehaviour {
    [SerializeField] private RectTransform _transactionViewParent;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    private List<TransactionViewConfig> _transactionViewConfigs;
    private List<TransactionView> _transactionViews;

    public void Init(List<TransactionViewConfig> transactionViewConfigs) {
        _transactionViewConfigs = transactionViewConfigs;

        _transactionViews = new List<TransactionView>();
        CreateTransactionViews();
    }

    private void CreateTransactionViews() {
        ClearTransactionViews();

        foreach (var iConfig in _transactionViewConfigs) {
            TransactionView newTransactionView = _companentsFactory.Get<TransactionView>(iConfig, _transactionViewParent);
            newTransactionView.Init(iConfig);

            _transactionViews.Add(newTransactionView);
        }
    }

    private void ClearTransactionViews() {
        if (_transactionViewParent.childCount == 0) return;

        foreach (RectTransform iTransform in _transactionViewParent) {
            Destroy(iTransform.gameObject);
        }

        _transactionViews.Clear();
    }
}
