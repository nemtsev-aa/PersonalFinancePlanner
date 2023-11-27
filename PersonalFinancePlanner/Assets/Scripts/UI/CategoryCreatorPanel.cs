using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CategoryCreatorPanel : UIPanel, IDisposable {
    public event Action IncomeCategoryCreated;
    public event Action ExpenditureCategoryCreated;
    public event Action EditCompleted;

    [SerializeField] private RectTransform _iconVariantViewParent;
    [SerializeField] private ToggleGroup _toggleGroup;
    [SerializeField] private InputFieldView _nameInput;
    [SerializeField] private InputFieldView _limitInput;

    [SerializeField] private Button _applyButton;
    [SerializeField] private Button _clearButton;

    private CategoryViewConfigs _categoryViewConfigs;
    private IconVariantViewConfigs _iconVariantViewConfigs;

    private UICompanentsFactory _companentsFactory;
    private Sprite _icon;

    private bool _isIncom;
    private CategoryViewConfig _editableCategory;

    public void Init(CategoryViewConfigs categoryViewConfigs, IconVariantViewConfigs iconVariantViewConfigs, UICompanentsFactory companentsFactory) {
        _categoryViewConfigs = categoryViewConfigs;
        _iconVariantViewConfigs = iconVariantViewConfigs;
        _companentsFactory = companentsFactory;

        AddListeners();
        CreateIconVariants();
    }

    public override void AddListeners() {
        base.AddListeners();

        _applyButton.onClick.AddListener(ApplyButtonClick);
        _clearButton.onClick.AddListener(ClearButtonClick);
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _applyButton.onClick.RemoveListener(ApplyButtonClick);
        _clearButton.onClick.RemoveListener(ClearButtonClick);
    }

    public void CreateIncomeCategory() => _isIncom = true;

    public void CreateExpenditureCategory() => _isIncom = false;

    public void EditCategory(CategoryViewConfig category) {
        _editableCategory = category;

        if (category is IncomeCategoryViewConfig) {
            _isIncom = true;

            IncomeCategoryViewConfig config = (IncomeCategoryViewConfig)category;
            _limitInput.SetValue($"{config.Target}");
        }  
        else 
        {
            _isIncom = false;
            ExpenditureCategoryViewConfig config = (ExpenditureCategoryViewConfig)category;
            _limitInput.SetValue($"{config.Limit}");
        }

        _nameInput.SetValue(category.Name);

        List<IconVariantViewConfig> configs = _iconVariantViewConfigs.Configs;
        configs = configs.Prepend(new IconVariantViewConfig(category.Icon)).ToList();

        CreateIconVariants();
    }

    private void CreateIconVariants() {
        while (_iconVariantViewParent.childCount > 0) {
            DestroyImmediate(_iconVariantViewParent.GetChild(0).gameObject);
        }

        foreach (var item in _iconVariantViewConfigs.Configs) {
            IconVariantView newIcon = _companentsFactory.Get<IconVariantView>(item, _iconVariantViewParent);
            newIcon.Toogle.group = _toggleGroup;
            newIcon.Init(item);

            newIcon.Selected += SetIcon;
        }
    }

    private void SetIcon(IconVariantView view) => _icon = view.Config.Icon;

    private void ApplyButtonClick() {
        if (_editableCategory != null)
            ÑompleteCreation();
        else
            CompleteEdit();
    }

    private void ÑompleteCreation() {
        if (_isIncom == false) {
            ExpenditureCategoryViewConfig viewConfig = new ExpenditureCategoryViewConfig(_nameInput.Value, float.Parse(_limitInput.Value), _icon);
            _categoryViewConfigs.AddExpenditureCategory(viewConfig);
            ExpenditureCategoryCreated?.Invoke();
        }
        else {
            IncomeCategoryViewConfig viewConfig = new IncomeCategoryViewConfig(_nameInput.Value, float.Parse(_limitInput.Value), _icon);
            _categoryViewConfigs.AddIncomeCategory(viewConfig);
            IncomeCategoryCreated?.Invoke();
        }
    }

    private void CompleteEdit() {
        if (_editableCategory is IncomeCategoryViewConfig) {
            IncomeCategoryViewConfig config = (IncomeCategoryViewConfig)_editableCategory;
            CategoryData data = new CategoryData(_nameInput.Value, _icon, float.Parse(_limitInput.Value), config.Value);
            config.SetCategoryData(data);
        }
        else
        {
            ExpenditureCategoryViewConfig config = (ExpenditureCategoryViewConfig)_editableCategory;
            CategoryData data = new CategoryData(_nameInput.Value, _icon, float.Parse(_limitInput.GetValue()), config.Value);
            config.SetCategoryData(data);
        }
    }

    private void ClearButtonClick() {
        _nameInput.Reset();
        _limitInput.Reset();

        _icon = null;
    }
}
