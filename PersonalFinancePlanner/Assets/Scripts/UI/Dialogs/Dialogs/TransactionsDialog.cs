using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransactionsDialog : Dialog {
    public event Action TransactionCreated;

    [SerializeField] private CategoryViewConfigs _configs;
    [SerializeField] private UICompanentsFactory _companentsFactory;
    [SerializeField] private TransactionDataList _transactionData;

    [SerializeField] private List<UIPanel> _panels = new List<UIPanel>();

    private CreatorTransactionPanel _creatorTransactionPanel;
    private SelectCategoryPanel _selectCategoryPanel;
    private TransactionsListPanel _transactionListPanel;

    public override void Init() {
        InitializationPanels();
        base.Init();
    }

    private void InitializationPanels() {
        _creatorTransactionPanel = GetPanelByType<CreatorTransactionPanel>();
        _creatorTransactionPanel.Init();
        _creatorTransactionPanel.Show(false);

        _selectCategoryPanel = GetPanelByType<SelectCategoryPanel>();
        _selectCategoryPanel.Init(_configs, _companentsFactory);
        _selectCategoryPanel.Show(false);

        _transactionListPanel = GetPanelByType<TransactionsListPanel>();
        _transactionListPanel.Init(_transactionData);
        _transactionListPanel.Show(true);
    }

    public override void AddListeners() {
        base.AddListeners();

        _creatorTransactionPanel.ShowCategorySelectionPanel += OnShowCategorySelectionPanel;
        _creatorTransactionPanel.TransactionDataCreated += OnTransactionDataCreated;

        _selectCategoryPanel.CategoryViewSelected += OnCategorySelected;
        _transactionListPanel.EditTransaction += OnEditTransaction;
    }

    public override void RemoveListeners() {
        base.AddListeners();
        _creatorTransactionPanel.ShowCategorySelectionPanel -= OnShowCategorySelectionPanel;
        _selectCategoryPanel.CategoryViewSelected -= OnCategorySelected;
        _transactionListPanel.EditTransaction -= OnEditTransaction;
    }

    public void ShowCreatorTransaction(CategoryViewConfig config, DateTime date) {
        _transactionListPanel.Show(false);
        _creatorTransactionPanel.Show(true);

        TransactionData transactionData = new TransactionData(date, config.GetCategory());

        CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(config, GetComponent<RectTransform>());
        newCategoryView.Init(config);
        
        _creatorTransactionPanel.SetTransactionData(transactionData);
        _creatorTransactionPanel.SetCategoryView(newCategoryView);
    }

    public void ShowTransactionsList() => _transactionListPanel.Show(true);
    
    private void OnTransactionDataCreated(TransactionData data) {
        _transactionData.Add(data);
        TransactionCreated?.Invoke();
        Close();
    }

    private void OnShowCategorySelectionPanel() => _selectCategoryPanel.Show(true);

    private void OnCategorySelected(CategoryView category) {
        _selectCategoryPanel.Show(false);
        _creatorTransactionPanel.SetCategoryView(category);
    } 

    private List<TransactionViewConfig> CrateTransactionViewConfigs() {
        if (_transactionData.List.Count() == 0)
            throw new ArgumentNullException($"TransactionDataList is empty");

        List<TransactionViewConfig> newTransactionViewConfigList = new List<TransactionViewConfig>();
        TransactionManager transactionManager = new TransactionManager(_configs, _transactionData);

        foreach (var iTransaction in transactionManager.Transactions) {
            TransactionViewConfig newTransactionViewConfig = new TransactionViewConfig(iTransaction);
            newTransactionViewConfigList.Add(newTransactionViewConfig);
        }

        return newTransactionViewConfigList;
    }

    private void OnEditTransaction(Transaction transaction) {
        _creatorTransactionPanel.SetTransactionData(transaction.TransactionData);
    }

    private T GetPanelByType<T>() where T : UIPanel {
        return (T)_panels.FirstOrDefault(panel => panel is T);
    }
}
