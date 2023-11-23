using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransactionsDialog : Dialog {
    [SerializeField] private CategoryViewConfigs _configs;
    [SerializeField] private List<UIPanel> _panels = new List<UIPanel>();

    private CreatorTransactionPanel _creatorTransactionPanel;
    private SelectCategoryPanel _selectCategoryPanel;
    private TransactionsListPanel _transactionListPanel;

    public override void Init() {
        base.Init();
        InitializationPanels();
    }

    private void InitializationPanels() {
        _creatorTransactionPanel = GetPanelByType<CreatorTransactionPanel>();
        _creatorTransactionPanel.Init();

        _selectCategoryPanel = GetPanelByType<SelectCategoryPanel>();
        _selectCategoryPanel.Init();

        _transactionListPanel = GetPanelByType<TransactionsListPanel>();
        _transactionListPanel.Init();
    }

    private T GetPanelByType<T>() where T : UIPanel {
        return (T)_panels.FirstOrDefault(panel => panel is T);
    }

    public override void AddListeners() {
        _creatorTransactionPanel.ShowCategorySelectionPanel += OnShowCategorySelectionPanel;
        _selectCategoryPanel.CategorySelected += OnCategorySelected;

    }

    public override void RemoveListeners() {
       
    }

    public void ShowCreatorTransaction(TransactionData data) {
        _creatorTransactionPanel.SetTransactionData(data);
        _creatorTransactionPanel.Show(true);
    }

    public void ShowTransactionsList() => _transactionListPanel.Show(true);
    
    private void OnShowCategorySelectionPanel() => _selectCategoryPanel.Show(true);

    private void OnCategorySelected(Category category) => _creatorTransactionPanel.SetCategory(category);

    private void ShowListClick() {
        //_showList.gameObject.SetActive(false);
        //_showCreator.gameObject.SetActive(true);

        //_creatorTransactionPanel.gameObject.SetActive(false);
        //_transactionListPanel.gameObject.SetActive(true);

        _transactionListPanel.Init(CrateTransactionViewConfigs());
    }

    private List<TransactionViewConfig> CrateTransactionViewConfigs() {
        if (_creatorTransactionPanel.TransactionDatas.Count() == 0)
            throw new ArgumentNullException($"TransactionDataList is empty");

        List<TransactionViewConfig> newTransactionViewConfigList = new List<TransactionViewConfig>();
        TransactionManager transactionManager = new TransactionManager(_configs, _creatorTransactionPanel.TransactionDatas);

        foreach (var iTransaction in transactionManager.Transactions) {
            TransactionViewConfig newTransactionViewConfig = new TransactionViewConfig(iTransaction);
            newTransactionViewConfigList.Add(newTransactionViewConfig);
        }

        return newTransactionViewConfigList;
    }

    private void ShowCreatorClick() {

    }
}
