using UnityEngine;

public class CategoryDialog : Dialog {
    [SerializeField] private CategoryViewConfigs _categoryViewConfigs;
    [SerializeField] private IconVariantViewConfigs _iconVariantViewConfigs;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    [SerializeField] private CreatorCategoryPanel _creatorCategory;
    [SerializeField] private CategoryViewsPanel _categoryViews;

    public override void Init() {
        base.Init();

        _creatorCategory.Init(_categoryViewConfigs, _iconVariantViewConfigs, _companentsFactory);
        _categoryViews.Init(_categoryViewConfigs, _companentsFactory);
    }

    public override void AddListeners() {

    }

    public override void RemoveListeners() {

    }
}
