using System.Collections.Generic;
using System.Linq;

public class DialogTypeVisitor : IDialogTypeVisitor {
    private readonly IEnumerable<Dialog> _dialogs;

    public DialogTypeVisitor(IEnumerable<Dialog> dialogs) {
        _dialogs = dialogs;
    }

    public Dialog Dialog { get; private set; }

    public void Visit(Dialog dialog) => Visit((dynamic)dialog);

    public void Visit(DesktopDialog desktop) => Dialog = _dialogs.FirstOrDefault(dialog => dialog is DesktopDialog);

    public void Visit(TransactionsDialog transactions) => Dialog = _dialogs.FirstOrDefault(dialog => dialog is TransactionsDialog);

    public void Visit(CategoryDialog category) => Dialog = _dialogs.FirstOrDefault(dialog => dialog is CategoryDialog);

    public void Visit(FinancialGoalsDialog financialGoals) => Dialog = _dialogs.FirstOrDefault(dialog => dialog is FinancialGoalsDialog);

    public void Visit(SettingsDialog settingsDialog) => Dialog = _dialogs.FirstOrDefault(dialog => dialog is SettingsDialog);

    public void Visit(AboutDialog aboutDialog) => Dialog = _dialogs.FirstOrDefault(dialog => dialog is AboutDialog);
}
