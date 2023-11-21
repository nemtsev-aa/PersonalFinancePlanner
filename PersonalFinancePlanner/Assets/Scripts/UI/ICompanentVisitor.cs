public interface ICompanentVisitor {
    void Visit(UICompanentConfig companent);
    void Visit(TransactionViewConfig transactionView);
    void Visit(IncomeCategoryViewConfig categoryView);
    void Visit(ExpenditureCategoryViewConfig categoryView);
    void Visit(IconVariantViewConfig iconVariantView);
}
