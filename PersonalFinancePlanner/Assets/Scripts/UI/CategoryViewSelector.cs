using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryViewSelector : MonoBehaviour, IDisposable {
    public event Action<List<Category>> CategorySelected;
    
    [SerializeField] private bool _incomeCategory;
    [SerializeField] private CategoryViewConfigs _viewConfigs;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    [SerializeField] private RectTransform _incomeParent;
    [SerializeField] private RectTransform _expenditureParent;

    [SerializeField] private Button _applySelection;

    private List<CategoryView> _incomeCategoryViews;
    private List<CategoryView> _expenditureCategoryViews;

    private IncomeCategoryViewConfigs _incomeConfigs;
    private ExpenditureCategoryViewConfigs _expenditureConfigs;

    public void Init() {
        AddListeners();

        if (_incomeCategory) {
            _incomeConfigs = _viewConfigs.IncomeCategory;
            _incomeCategoryViews = new List<CategoryView>();
            CreateIncomeCategoryView();
        }
        else {
            _expenditureConfigs = _viewConfigs.ExpenditureCategory;
            _expenditureCategoryViews = new List<CategoryView>();
            CreateExpenditureCategoryViews();
        }
    }

    private void AddListeners() {
        _applySelection.onClick.AddListener(ApplySelectionClick);
    }

    private void RemoveListeners() {
        _applySelection.onClick.RemoveListener(ApplySelectionClick);
    }

    private void CreateIncomeCategoryView() {
        _incomeCategoryViews = new List<CategoryView>();

        foreach (var iConfig in _incomeConfigs.Configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _incomeParent);
            newCategoryView.Init(iConfig);

            newCategoryView.Selected += IncomeCategoryViewSelected;
        }
    }

    private void CreateExpenditureCategoryViews() {
        _expenditureCategoryViews = new List<CategoryView>();

        foreach (var iConfig in _expenditureConfigs.Configs) {
            CategoryView newCategoryView = _companentsFactory.Get<CategoryView>(iConfig, _expenditureParent);
            newCategoryView.Init(iConfig);
            
            newCategoryView.Selected += ExpenditureCategoryViewSelected;
        }
    }

    private void IncomeCategoryViewSelected(CategoryView view) {
        if (_incomeCategoryViews.Contains(view) == true)
            _incomeCategoryViews.Remove(view);
        else
            _incomeCategoryViews.Add(view);
    }

    private void ExpenditureCategoryViewSelected(CategoryView view) {
        if (_expenditureCategoryViews.Contains(view) == true)
            _expenditureCategoryViews.Remove(view);
        else
            _expenditureCategoryViews.Add(view);
    }

    private void ClearCategoryViews(List<CategoryView> categoryViews) {
        foreach (var iView in categoryViews) {
            Destroy(iView.gameObject);
        }

        categoryViews.Clear();
    }

    private void ApplySelectionClick() {
        if (_incomeCategory) {
            if (_incomeCategoryViews.Count > 0) {
                List<Category> incomeCategories = new List<Category>();
                foreach (var item in _incomeCategoryViews) {
                    incomeCategories.Add(item.Config.GetCategory());
                }

                CategorySelected?.Invoke(incomeCategories);
            }
        } else {
            if (_expenditureCategoryViews.Count > 0) {
                List<Category> expenditureCategories = new List<Category>();
                foreach (var item in _expenditureCategoryViews) {
                    expenditureCategories.Add(item.Config.GetCategory());
                }

                CategorySelected?.Invoke(expenditureCategories);
            }
        }

        gameObject.SetActive(false);
    }

    public void Dispose() => RemoveListeners();
}
