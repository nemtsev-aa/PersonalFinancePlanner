using UnityEngine;

public class CategoryDialog : Dialog {
    [SerializeField] private CategoryViewConfigs _categoryViewConfigs;
    [SerializeField] private IconVariantViewConfigs _iconVariantViewConfigs;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    [SerializeField] private CategoryCreatorPanel _creator;
    [SerializeField] private CategoryViewsPanel _views;

    public override void Init() {
        base.Init();

        _creator.Init(_categoryViewConfigs, _iconVariantViewConfigs, _companentsFactory);
        _views.Init(_categoryViewConfigs, _companentsFactory);
    }

    public override void AddListeners() {
        base.AddListeners();
    }

    public override void RemoveListeners() {
        base.RemoveListeners();
    }
}
