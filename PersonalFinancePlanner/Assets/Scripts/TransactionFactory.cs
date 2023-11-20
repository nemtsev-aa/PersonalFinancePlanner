public class TransactionFactory {
    private CategoryConfigs _categoryConfigs;

    public TransactionFactory(CategoryConfigs categoryConfigs) {
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
