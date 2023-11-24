public class TransactionFactory {
    private CategoryViewConfigs _categoryConfigs;
    private IncomeCategoryViewConfigs _incomeConfigs;
    private ExpenditureCategoryViewConfig _expenditureConfig;

    public TransactionFactory(CategoryViewConfigs categoryConfigs) {
        _categoryConfigs = categoryConfigs;
    }

    //public Transaction Get(TransactionData data) {
    //    return new Transaction(data);
    //}

    //private Category GetCategory(TransactionData data) {

    //    Category category = new Category(data.Category.Name, _categoryConfigs.GetSpriteByCategoryName(data.Category.Name));

    //    return category;
    //}
}
