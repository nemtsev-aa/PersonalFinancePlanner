using UnityEngine;

public class CategoriesWindow : MonoBehaviour {
    [SerializeField] private CategoryViewConfigs _categoryViewConfigs;
    [SerializeField] private IconVariantViewConfigs _iconVariantViewConfigs;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    [SerializeField] private CreatorCategory _creatorCategory;
    [SerializeField] private CategoryViews _categoryViews;

    private void Start() {
        _creatorCategory.Init(_categoryViewConfigs, _iconVariantViewConfigs, _companentsFactory);
        _categoryViews.Init(_categoryViewConfigs, _companentsFactory);
    }
}
