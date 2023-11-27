public class TransactionFactory {
    private CategoryViewConfigs _categoryConfigs;
    private IncomeCategoryViewConfigs _incomeConfigs;
    private ExpenditureCategoryViewConfig _expenditureConfig;

    public TransactionFactory(CategoryViewConfigs categoryConfigs) {
        _categoryConfigs = categoryConfigs;
    }
}
