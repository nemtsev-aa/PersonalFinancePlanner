public interface ICompanentVisitor {
    void Visit(UICompanentConfig companent);
    void Visit(TransactionViewConfig transactionView);
    void Visit(IncomeCategoryViewConfig categoryView);
    void Visit(ExpenditureCategoryViewConfig categoryView);
    void Visit(IconVariantViewConfig iconVariantView);
    void Visit(SelectorViewConfig selectorView);
    void Visit(IncomeWidgetConfig incomWidget);
    void Visit(ExpenditureWidgetConfig incomWidget);
}
