using System;
using UnityEngine;
using UnityEngine.UI;

public class CategorySelectionView : MonoBehaviour, IDisposable {
    public event Action SelectCategory;

    [SerializeField] private Transform SelectorContainer;
    [SerializeField] private Button _selectCategory;

    [SerializeField] private Transform CategoryViewContainer;

    private CategoryView _categoryView;

    public void Init() { 
        AddListeners();
        Reset();
    }

    public void Reset() {
        ShowCategoryView(false);
        ShowSelector(false);
        _categoryView = null;
    }

    public void SetCategoryView(CategoryView view) {
        _categoryView = view;
        ShowCategoryView(true);
    }

    private void AddListeners() {
        _selectCategory.onClick.AddListener(SelectCategoryClick);
    }

    private void SelectCategoryClick() {
        SelectCategory?.Invoke();
        ShowSelector(false);
    }

    private void ShowSelector(bool status) {
        SelectorContainer.gameObject.SetActive(status);
        CategoryViewContainer.gameObject.SetActive(!status);
    }

    private void ShowCategoryView(bool status) {
        CategoryViewContainer.gameObject.SetActive(status);
        SelectorContainer.gameObject.SetActive(!status);
    }

    public void Dispose() {
        _selectCategory.onClick.RemoveListener(SelectCategoryClick);
    }
}
