using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransactionsDialog : Dialog {
    public event Action<TransactionData> TransactionCreated;

    [SerializeField] private CategoryViewConfigs _configs;
    [SerializeField] private UICompanentsFactory _companentsFactory;
    
    private TransactionManager _transactionManager;
    private DialogMediator _dialogMediator;

    private CreatorTransactionPanel _creatorTransactionPanel;
    private SelectCategoryPanel _selectCategoryPanel;
    private TransactionsListPanel _transactionListPanel;
    private FilterPanel _filterPanel;

    public override void Init(DialogMediator mediator) {
        if (IsInit == true)
            return;

        _dialogMediator = mediator;
        _transactionManager = _dialogMediator.TransactionManager;

        InitializationPanels();

        base.Init(mediator);

        IsInit = true;
    }

    public override void Show(bool value) {
        base.Show(value);

        ShowPanel<TransactionsListPanel>(value);
    }

    private void InitializationPanels() {
        _creatorTransactionPanel = GetPanelByType<CreatorTransactionPanel>();
        _creatorTransactionPanel.Init(_dialogMediator);
        _creatorTransactionPanel.Show(false);

        _selectCategoryPanel = GetPanelByType<SelectCategoryPanel>();
        _selectCategoryPanel.Init(_configs, _companentsFactory, _dialogMediator);
        _selectCategoryPanel.Show(false);

        _transactionListPanel = GetPanelByType<TransactionsListPanel>();
        _transactionListPanel.Init(_transactionManager, _dialogMediator);
        _transactionListPanel.Show(true);

        _filterPanel = GetPanelByType<FilterPanel>();
        _filterPanel.Init(_transactionManager);
        _filterPanel.Show(false);
    }

    public override void AddListeners() {
        base.AddListeners();

        _creatorTransactionPanel.ShowCategorySelectionPanel += OnShowCategorySelectionPanel;
        _creatorTransactionPanel.TransactionDataCreated += OnTransactionDataCreated;
        _selectCategoryPanel.CategoryViewSelected += OnCategorySelected;
        _transactionListPanel.EditTransaction += OnEditTransaction;
        _transactionListPanel.ShowFilterPanel += OnShowFilterPanel;
        _filterPanel.FilterSelected += OnFilterSelected;
    }

    public override void RemoveListeners() {
        base.AddListeners();
        _creatorTransactionPanel.ShowCategorySelectionPanel -= OnShowCategorySelectionPanel;
        _selectCategoryPanel.CategoryViewSelected -= OnCategorySelected;
        _transactionListPanel.EditTransaction -= OnEditTransaction;
        _transactionListPanel.ShowFilterPanel -= OnShowFilterPanel;
        _filterPanel.FilterSelected -= OnFilterSelected;
    }

    public void ShowCreatorTransaction(CategoryViewConfig config, DateTime date) {
        _transactionListPanel.Show(false);
        _creatorTransactionPanel.Show(true);

        TransactionData transactionData = new TransactionData(date, config.GetCategory());
        
        _creatorTransactionPanel.SetTransactionData(transactionData);
        _creatorTransactionPanel.SetCategoryData(transactionData.Category.CategoryData);
    }

    public void ShowTransactionsList() => _transactionListPanel.Show(true);

    private void OnTransactionDataCreated(TransactionData data) {
        _creatorTransactionPanel.Show(false);
        _transactionListPanel.Show(true);

        TransactionCreated?.Invoke(data);
    }

    private void OnShowCategorySelectionPanel() => _selectCategoryPanel.Show(true);

    private void OnCategorySelected(CategoryView category) {
        _selectCategoryPanel.Show(false);
        _creatorTransactionPanel.SetCategoryView(category);
    }

    private List<TransactionViewConfig> CrateTransactionViewConfigs() {
        if (_transactionManager.Transactions.Count == 0)
            throw new ArgumentNullException($"Transactions List is empty");

        List<TransactionViewConfig> newTransactionViewConfigList = new List<TransactionViewConfig>();

        foreach (var iTransaction in _transactionManager.Transactions) {
            TransactionViewConfig newTransactionViewConfig = new TransactionViewConfig(iTransaction);

            newTransactionViewConfigList.Add(newTransactionViewConfig);
        }

        return newTransactionViewConfigList;
    }

    private void OnEditTransaction(Transaction transaction) {
        _creatorTransactionPanel.Show(true);
        _transactionListPanel.Show(false);
        _creatorTransactionPanel.SetTransactionData(transaction.Data);
    }

    private void OnShowFilterPanel() {
        if (_filterPanel.gameObject.activeInHierarchy == true) {
            _transactionListPanel.SetTransactionsList(_transactionManager.Transactions);
            _filterPanel.Show(false);
        }
        else
            _filterPanel.Show(true);
    }

    private void OnFilterSelected(IReadOnlyList<Transaction> transactions) => _transactionListPanel.SetTransactionsList(transactions);
}
