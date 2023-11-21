using UnityEngine;

[CreateAssetMenu(fileName = "CategoryViewConfigs", menuName = "Config/CategoryViewConfigs")]
public class CategoryViewConfigs : ScriptableObject {
    [SerializeField] private IncomeCategoryViewConfigs _incomeCategory;
    [SerializeField] private ExpenditureCategoryViewConfigs _expenditureCategory;

    public IncomeCategoryViewConfigs IncomeCategory => _incomeCategory;
    public ExpenditureCategoryViewConfigs ExpenditureCategory => _expenditureCategory;

    public void AddIncomeCategory(IncomeCategoryViewConfig config) {
        _incomeCategory.AddCategory(config);
    }

    public void AddExpenditureCategory(ExpenditureCategoryViewConfig config) {
        _expenditureCategory.AddCategory(config);
    }
}
