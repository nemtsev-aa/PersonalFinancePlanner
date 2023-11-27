using System;

public class DialogMediator {
    public DialogMediator(DialogSwitcher dialogSwitcher, TransactionManager transactionManager, CategoryManager categoryManager) {
        DialogSwitcher = dialogSwitcher;
        TransactionManager = transactionManager;
        CategoryManager = categoryManager;

        GetDialogs();
        InitializationDialogs();
        AddListeners();
    }

    public DesktopDialog DesktopDialog { get; private set; }
    public TransactionsDialog TransactionsDialog { get; private set; }
    public CategoryDialog CategoryDialog { get; private set; }
    public FinancialGoalsDialog FinancialGoalsDialog { get; private set; }
    public SettingsDialog SettingsDialog { get; private set; }
    public AboutDialog AboutDialog { get; private set; }

    public DialogSwitcher DialogSwitcher { get; private set; }
    public TransactionManager TransactionManager { get; private set; }
    public CategoryManager CategoryManager { get; private set; }

    private void GetDialogs() {
        DesktopDialog = DialogSwitcher.GetDialogByType(DialogTypes.DesktopDialog).GetComponent<DesktopDialog>();
        TransactionsDialog = DialogSwitcher.GetDialogByType(DialogTypes.Transactions).GetComponent<TransactionsDialog>();
        CategoryDialog = DialogSwitcher.GetDialogByType(DialogTypes.Category).GetComponent<CategoryDialog>();
        FinancialGoalsDialog = DialogSwitcher.GetDialogByType(DialogTypes.FinancialGoals).GetComponent<FinancialGoalsDialog>();
        SettingsDialog = DialogSwitcher.GetDialogByType(DialogTypes.Settings).GetComponent<SettingsDialog>();
        AboutDialog = DialogSwitcher.GetDialogByType(DialogTypes.About).GetComponent<AboutDialog>();
    }

    private void InitializationDialogs() {
        DesktopDialog.Init(this);
        TransactionsDialog.Init(this);
        CategoryDialog.Init(this);
        FinancialGoalsDialog.Init(this);
        SettingsDialog.Init(this);
        AboutDialog.Init(this);
    }

    private void AddListeners() {
        SubscribeToDesktopDialogActions();
        SubscribeToCategoryDialogActions();
        SubscribeToTransactionsDialogActions();
    }

    #region DesktopDialogActions
    private void SubscribeToDesktopDialogActions() {
        DesktopDialog.CreateIncomeTransaction += OnCreateIncomeTransaction;
        DesktopDialog.CreateExpenditureTransaction += OnCreateExpenditureTransaction;
        DesktopDialog.EditCategory += OnEditCategory;
    }

    private void OnCreateIncomeTransaction(IncomeCategoryViewConfig config, DateTime date) {
        TransactionsDialog.Show(true);
        TransactionsDialog.ShowCreatorTransaction(config, date);
    }

    private void OnCreateExpenditureTransaction(ExpenditureCategoryViewConfig config, DateTime date) {
        TransactionsDialog.Show(true);
        TransactionsDialog.ShowCreatorTransaction(config, date);
    }

    private void OnEditCategory(CategoryViewConfig config) {
        CategoryDialog.Show(true);
        CategoryDialog.EditCategory(config);
    }
    #endregion

    #region CategoryDialogActions
    private void SubscribeToCategoryDialogActions() {
        CategoryDialog.EditCompleted += OnEditCompleted;
        CategoryDialog.CategoryListChanged += OnCategoryListChanged;
    }

    private void OnEditCompleted() {
        CategoryDialog.Show(false);
        DesktopDialog.UpdateWidgets();
        DesktopDialog.Show(true);
    }

    private void OnCategoryListChanged() {
        DesktopDialog.UpdateWidgets();
    }
    #endregion

    #region TransactionDialogActions
    private void SubscribeToTransactionsDialogActions() {
        TransactionsDialog.TransactionCreated += OnTransactionCreated;
    }

    private void OnTransactionCreated(TransactionData data) {
        TransactionManager.AddTransaction(data);
        TransactionsDialog.Show(false);
        CategoryManager.UpdateCategories(TransactionManager.Transactions);
        
        DesktopDialog.Show(true);
    }

    #endregion

    public void UpdateCategories() => CategoryManager.UpdateCategories(TransactionManager.Transactions);
}