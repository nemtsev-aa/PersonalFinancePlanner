using System.Collections.Generic;
using System.Linq;

public class UICompanentVisitor : ICompanentVisitor {
    private readonly IEnumerable<UICompanent> _companents;

    public UICompanentVisitor(IEnumerable<UICompanent> companents) {
        _companents = companents;
    }

    public UICompanent Companent { get; private set; }

    public void Visit(UICompanentConfig companent) => Visit((dynamic)companent);

    public void Visit(TransactionViewConfig panel) => Companent = _companents.FirstOrDefault(companent => companent is TransactionView);

    public void Visit(IncomeCategoryViewConfig categoryView) => Companent = _companents.FirstOrDefault(companent => companent is CategoryView);

    public void Visit(ExpenditureCategoryViewConfig categoryView) => Companent = _companents.FirstOrDefault(companent => companent is CategoryView);

    public void Visit(IconVariantViewConfig iconVariantView) => Companent = _companents.FirstOrDefault(companent => companent is IconVariantView);

    public void Visit(SelectorViewConfig selectorView) => Companent = _companents.FirstOrDefault(companent => companent is SelectorView);

    public void Visit(IncomeWidgetConfig incomWidget) => Companent = _companents.FirstOrDefault(companent => companent is IncomeWidgetView);

    public void Visit(ExpenditureWidgetConfig incomWidget) => Companent = _companents.FirstOrDefault(companent => companent is ExpenditureWidgetView);
}