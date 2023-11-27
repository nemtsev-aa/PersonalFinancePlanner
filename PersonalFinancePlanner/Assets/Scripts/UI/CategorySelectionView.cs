using System;
using UnityEngine;
using UnityEngine.UI;

public class CategorySelectionView : MonoBehaviour, IDisposable {
    public event Action SelectCategory;

    [SerializeField] private Transform SelectorContainer;
    [SerializeField] private Button _selectCategory;
    [SerializeField] private Transform _categoryViewContainer;
    [SerializeField] private CategoryView _categoryView;

    public void Init() {
        AddListeners();
        Reset();
    }

    public void Reset() {
        ShowCategoryView(false);
        ShowSelector(true);
    }

    public void ShowCategoryView() => ShowCategoryView(true);

    public void SetCategoryData(CategoryData data) {
        ShowCategoryView(true);
        _categoryView.SetCategoryData(data);
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
        _categoryViewContainer.gameObject.SetActive(!status);
    }

    private void ShowCategoryView(bool status) {
        _categoryViewContainer.gameObject.SetActive(status);
        SelectorContainer.gameObject.SetActive(!status);
    }

    public void Dispose() {
        _selectCategory.onClick.RemoveListener(SelectCategoryClick);
    }
}
