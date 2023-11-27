using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectCategoryPanel : UIPanel {
    public event Action<CategoryView> CategoryViewSelected;

    [SerializeField] private RectTransform _incomeCategoryViewParent;
    [SerializeField] private RectTransform _expenditureCategoryViewParent;

    private CategoryViewConfigs _categoryViewConfigs;
    private IncomeCategoryViewConfigs _incomeConfigs;
    private ExpenditureCategoryViewConfigs _expenditureConfigs;

    private UICompanentsFactory _companentsFactory;
    private List<CategoryView> _incomeCategoryViews;
    private List<CategoryView> _expenditureCategoryViews;

    public void Init(CategoryViewConfigs categoryViewConfigs, UICompanentsFactory companentsFactory, DialogMediator dialogMediator) {
        _categoryViewConfigs = categoryViewConfigs;
        _companentsFactory = companentsFactory;

        _incomeConfigs = _categoryViewConfigs.IncomeCategory;
        _expenditureConfigs = _categoryViewConfigs.ExpenditureCategory;
    }

    public override void AddListeners() { 
        CreateIncomeCategoryView();
    }

    public override void RemoveListeners() {
        CreateExpenditureCategoryView();
    }

    private void CreateIncomeCategoryView() {
        _incomeCategoryViews = new List<CategoryView>();

        foreach (var iConfig in _incomeConfigs.Configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _incomeCategoryViewParent);
            newCategoryView.Init(iConfig);
            newCategoryView.Selected += OnCategoryViewSelect;

            _incomeCategoryViews.Add(newCategoryView);
        }
    }

    private void CreateExpenditureCategoryView() {
        _expenditureCategoryViews = new List<CategoryView>();

        foreach (var iConfig in _expenditureConfigs.Configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _expenditureCategoryViewParent);
            newCategoryView.Init(iConfig);
            newCategoryView.Selected += OnCategoryViewSelect;
            _expenditureCategoryViews.Add(newCategoryView);
        }
    }

    private void OnCategoryViewSelect(CategoryView categoryView) {
        categoryView.Selected -= OnCategoryViewSelect;
        CategoryViewSelected?.Invoke(categoryView);
    }
}
