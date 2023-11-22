public interface IDialogTypeVisitor {
    void Visit(Dialog dialog);
    void Visit(DesktopDialog desktop);
    void Visit(TransactionsDialog transactions);
    void Visit(CategoryDialog category);
    void Visit(FinancialGoalsDialog financialGoals);
    void Visit(SettingsDialog settingsDialog);
    void Visit(AboutDialog aboutDialog);
}
