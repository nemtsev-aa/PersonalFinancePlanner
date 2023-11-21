using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryViews : MonoBehaviour {
    [SerializeField] private RectTransform _incomeCategoryViewParent;
    [SerializeField] private RectTransform _expenditureCategoryViewParent;
    [SerializeField] private Button _addCategoryButton;

    private CategoryViewConfigs _categoryViewConfigs;
    private IncomeCategoryViewConfigs _incomeConfigs;
    private ExpenditureCategoryViewConfigs _expenditureConfigs;
    
    private UICompanentsFactory _companentsFactory;
    private List<CategoryView> _incomeCategoryViews;
    private List<CategoryView> _expenditureCategoryViews;

    public void Init(CategoryViewConfigs categoryViewConfigs, UICompanentsFactory companentsFactory) {
        _categoryViewConfigs = categoryViewConfigs;
        _companentsFactory = companentsFactory;

        _incomeConfigs = _categoryViewConfigs.IncomeCategory;
        _expenditureConfigs = _categoryViewConfigs.ExpenditureCategory;

        CreateSubscribers();
    }

    private void CreateSubscribers() {
        _addCategoryButton.onClick.AddListener(AddCategoryButtonClick);
    }

    private void AddCategoryButtonClick() {
        
    }

    private void CreateIncomeCategoryView() {
        _incomeCategoryViews = new List<CategoryView>();
        
        foreach (var iConfig in _incomeConfigs.Configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _incomeCategoryViewParent);
            newCategoryView.Init(iConfig);

            _incomeCategoryViews.Add(newCategoryView);
        }
    }

    private void CreateExpenditureCategoryView() {
        _expenditureCategoryViews = new List<CategoryView>();

        foreach (var iConfig in _expenditureConfigs.Configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _expenditureCategoryViewParent);
            newCategoryView.Init(iConfig);

            _expenditureCategoryViews.Add(newCategoryView);
        }
    }
}
