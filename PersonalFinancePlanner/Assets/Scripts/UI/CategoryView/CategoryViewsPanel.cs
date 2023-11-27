using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryViewsPanel : UIPanel {
    public event Action IncomeCategoryAdded;
    public event Action ExpenditureCategoryAdded;
    public event Action CategoryListChanged;

    [SerializeField] private RectTransform _incomeCategoryViewParent;
    [SerializeField] private RectTransform _expenditureCategoryViewParent;
    [SerializeField] private Button _addIncomeCategoryButton;
    [SerializeField] private Button _addExpenditureCategoryButton;

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

        AddListeners();
        
        CreateIncomeCategoryView();
        CreateExpenditureCategoryViews();
    }

    public override void AddListeners() {
        base.AddListeners();

        _addIncomeCategoryButton.onClick.AddListener(AddIncomeCategoryButtonClick);
        _addExpenditureCategoryButton.onClick.AddListener(AddExpenditureCategoryButtonClick);
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _addIncomeCategoryButton.onClick.RemoveListener(AddIncomeCategoryButtonClick);
        _addExpenditureCategoryButton.onClick.RemoveListener(AddExpenditureCategoryButtonClick);
    }

    public void UpdateIncomeCategoryView() {
        ClearCategoryViews(_incomeCategoryViews);
        CreateIncomeCategoryView();
        CategoryListChanged?.Invoke();
    }

    public void UpdateExpenditureCategoryView() {
        ClearCategoryViews(_expenditureCategoryViews);
        CreateExpenditureCategoryViews();
        CategoryListChanged?.Invoke();
    }

    private void CreateIncomeCategoryView() {
        _incomeCategoryViews = new List<CategoryView>();
        
        foreach (var iConfig in _incomeConfigs.Configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _incomeCategoryViewParent);
            newCategoryView.Init(iConfig);

            _incomeCategoryViews.Add(newCategoryView);
        }
    }

    private void CreateExpenditureCategoryViews() {
        _expenditureCategoryViews = new List<CategoryView>();

        foreach (var iConfig in _expenditureConfigs.Configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _expenditureCategoryViewParent);
            newCategoryView.Init(iConfig);

            _expenditureCategoryViews.Add(newCategoryView);
        }
    }

    private void ClearCategoryViews(List<CategoryView> categoryViews) {
        foreach (var iView in categoryViews) {
            Destroy(iView.gameObject);
        }

        categoryViews.Clear();
    }

    private void AddIncomeCategoryButtonClick() => IncomeCategoryAdded?.Invoke();

    private void AddExpenditureCategoryButtonClick() => ExpenditureCategoryAdded?.Invoke();

}
