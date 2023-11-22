using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TransactionsDialog : Dialog {
    [SerializeField] private IncomeCategoryViewConfigs _configs;
    [Space(10)]
    [SerializeField] private CreatorTransactionPanel _creatorTransaction;
    [SerializeField] private TransactionsListPanel _transactionList;

    [SerializeField] private Button _showList;
    [SerializeField] private Button _showCreator;

    public override void Init() {
        base.Init();
        _creatorTransaction.Init(_configs);
    }

    public override void AddListeners() {
        _showList.onClick.AddListener(ShowListClick);
        _showCreator.onClick.AddListener(ShowCreatorClick);
    }

    public override void RemoveListeners() {
        _showList.onClick.RemoveListener(ShowListClick);
        _showCreator.onClick.RemoveListener(ShowCreatorClick);
    }

    private void ShowListClick() {
        _showList.gameObject.SetActive(false);
        _showCreator.gameObject.SetActive(true);

        _creatorTransaction.gameObject.SetActive(false);
        _transactionList.gameObject.SetActive(true);

        _transactionList.Init(CrateTransactionViewConfigs());
    }

    private List<TransactionViewConfig> CrateTransactionViewConfigs() {
        if (_creatorTransaction.TransactionDatas.Count() == 0)
            throw new ArgumentNullException($"TransactionDataList is empty");

        List<TransactionViewConfig> newTransactionViewConfigList = new List<TransactionViewConfig>();
        TransactionManager transactionManager = new TransactionManager(_configs, _creatorTransaction.TransactionDatas);

        foreach (var iTransaction in transactionManager.Transactions) {
            TransactionViewConfig newTransactionViewConfig = new TransactionViewConfig(iTransaction);
            newTransactionViewConfigList.Add(newTransactionViewConfig);
        }

        return newTransactionViewConfigList;
    }

    private void ShowCreatorClick() {
        _showCreator.gameObject.SetActive(false);
        _showList.gameObject.SetActive(true);

        _transactionList.gameObject.SetActive(false);
        _creatorTransaction.gameObject.SetActive(true);
    }

}
