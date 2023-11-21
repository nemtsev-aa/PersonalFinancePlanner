using System.Collections.Generic;
using UnityEngine;

public class CategoryViews : MonoBehaviour {
    [SerializeField] private RectTransform _incomeCategoryViewParent;
    [SerializeField] private RectTransform _expenditureCategoryViewParent;
    
    private CategoryViewConfigs _categoryViewConfigs;
    private IncomeCategoryViewConfigs _incomeConfigs;
    private ExpenditureCategoryViewConfigs _expenditureConfigs;
    
    private UICompanentsFactory _companentsFactory;
    private List<CategoryView> _incomeCategoryViews;
    private List<CategoryView> _expenditureCategoryViews;

    private void Start() {
        _companentsFactory.Init();

        CreateIncomeCategoryView(_incomeConfigs.Configs);
        CreateExpenditureCategoryView(_expenditureConfigs.Configs);
    }

    public void Init(CategoryViewConfigs categoryViewConfigs, UICompanentsFactory companentsFactory) {
        _categoryViewConfigs = categoryViewConfigs;
        _companentsFactory = companentsFactory;

        _incomeConfigs = _categoryViewConfigs.IncomeCategory;
        _expenditureConfigs = _categoryViewConfigs.ExpenditureCategory;
    }

    private void CreateIncomeCategoryView(List<IncomeCategoryViewConfig> configs) {
        _incomeCategoryViews = new List<CategoryView>();
        
        foreach (var iConfig in configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _incomeCategoryViewParent);
            newCategoryView.Init(iConfig);

            _incomeCategoryViews.Add(newCategoryView);
        }
    }

    private void CreateExpenditureCategoryView(List<ExpenditureCategoryViewConfig> configs) {
        _expenditureCategoryViews = new List<CategoryView>();

        foreach (var iConfig in configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _expenditureCategoryViewParent);
            newCategoryView.Init(iConfig);

            _expenditureCategoryViews.Add(newCategoryView);
        }
    }
}
