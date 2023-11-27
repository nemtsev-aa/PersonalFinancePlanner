using System.Collections.Generic;
using System.Linq;

public class CategoryManager {
    private CategoryViewConfigs _categoriesConfig;
    private IReadOnlyList<Transaction> _transactions;

    public CategoryManager(CategoryViewConfigs categoriesConfig) {
        _categoriesConfig = categoriesConfig;
    }
    
    public void UpdateCategories(IReadOnlyList<Transaction> transactions) {
        _transactions = transactions;

        foreach (var iCategory in _categoriesConfig.IncomeCategory.Configs) {
            iCategory.SetCategoryValue(GetPaymentAmountByCategory(iCategory.Name));
        }

        foreach (var iCategory in _categoriesConfig.ExpenditureCategory.Configs) {
            iCategory.SetCategoryValue(GetPaymentAmountByCategory(iCategory.Name));
        }
    }

    private float GetPaymentAmountByCategory(string name) {
        IEnumerable<Transaction> filter = _transactions.Where(t => t.Category.Name == name);
        float summ = 0;

        foreach (var iTransaction in filter) {
            summ += iTransaction.PaymentAmount;
        }

        return summ;
    }
}
