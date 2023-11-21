public class TransactionFactory {
    private IncomeCategoryViewConfigs _categoryConfigs;

    public TransactionFactory(IncomeCategoryViewConfigs categoryConfigs) {
        _categoryConfigs = categoryConfigs;
    }

    public Transaction Get(TransactionData data) {
        Category category = GetCategory(data);
        data.SetCategory(category);

        return new Transaction(data);
    }

    private Category GetCategory(TransactionData data) {
        Category category = new Category(data.Category.Name, _categoryConfigs.GetSpriteByCategoryName(data.Category.Name));

        return category;
    }
}
