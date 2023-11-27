using System;
using UnityEngine;

public class CategoryDialog : Dialog {
    public event Action EditCompleted;
    public event Action CategoryListChanged;

    [SerializeField] private CategoryViewConfigs _categoryViewConfigs;
    [SerializeField] private IconVariantViewConfigs _iconVariantViewConfigs;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    [SerializeField] private CategoryCreatorPanel _creator;
    [SerializeField] private CategoryViewsPanel _views;

    public override void Init(DialogMediator mediator) {
        if (IsInit == true)
            return;

        base.Init(mediator);

        _creator.Init(_categoryViewConfigs, _iconVariantViewConfigs, _companentsFactory);
        _views.Init(_categoryViewConfigs, _companentsFactory);

        IsInit = true;
    }

    public override void AddListeners() {
        base.AddListeners();

        _views.IncomeCategoryAdded += OnIncomeCategoryAdded;
        _views.ExpenditureCategoryAdded += OnExpenditureCategoryAdded;
        _views.CategoryListChanged += OnCategoryListChanged;

        _creator.IncomeCategoryCreated += OnIncomeCategoryCreated;
        _creator.ExpenditureCategoryCreated += OnExpenditureCategoryCreated;
        _creator.EditCompleted += OnEditCompleted;
    }

    public void EditCategory(CategoryViewConfig config) {
        _creator.EditCategory(config);
        _views.Show(false);
        _creator.Show(true);
    }

    public void ShowCategoryViewsPanel() {
        _creator.Show(false);
        _views.Show(true);
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _views.IncomeCategoryAdded -= OnIncomeCategoryAdded;
        _views.ExpenditureCategoryAdded -= OnExpenditureCategoryAdded;

        _creator.IncomeCategoryCreated -= OnIncomeCategoryCreated;
        _creator.ExpenditureCategoryCreated -= OnExpenditureCategoryCreated;
    }

    private void OnIncomeCategoryAdded() {
        _views.Show(false);
        _creator.Show(true);

        _creator.CreateIncomeCategory();
    }

    private void OnExpenditureCategoryAdded() {
        _views.Show(false);
        _creator.Show(true);

        _creator.CreateExpenditureCategory();
    }

    private void OnIncomeCategoryCreated() {
        _creator.Show(false);
       
        _views.UpdateIncomeCategoryView();
        _views.Show(true);
    }

    private void OnExpenditureCategoryCreated() {
        _creator.Show(false);

        _views.UpdateExpenditureCategoryView();
        _views.Show(true);
    } 

    private void OnEditCompleted() => EditCompleted?.Invoke();
    private void OnCategoryListChanged() => CategoryListChanged?.Invoke();
}
