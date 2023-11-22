using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatorCategoryPanel : MonoBehaviour, IDisposable {
    [SerializeField] private RectTransform _iconVariantViewParent;
    [SerializeField] private ToggleGroup _toggleGroup;
    [SerializeField] private TMP_InputField _nameInput;

    [SerializeField] private Button _applyButton;
    [SerializeField] private Button _clearButton;

    private CategoryViewConfigs _categoryViewConfigs;
    private IconVariantViewConfigs _iconVariantViewConfigs;
    private UICompanentsFactory _companentsFactory;
    private bool _isIncom;
    private Sprite _icon;

    public void Init(CategoryViewConfigs categoryViewConfigs, IconVariantViewConfigs iconVariantViewConfigs, UICompanentsFactory companentsFactory) {
        _categoryViewConfigs = categoryViewConfigs;
        _iconVariantViewConfigs = iconVariantViewConfigs;
        _companentsFactory = companentsFactory;

        CreateSubscribers();
        CreateIconVariants();
    }

    private void CreateSubscribers() {
        _applyButton.onClick.AddListener(ApplyButtonClick);
        _clearButton.onClick.AddListener(ClearButtonClick);
    }

    private void CreateIconVariants() {
        _companentsFactory.Init();
        
        foreach (var item in _iconVariantViewConfigs.Configs) {
            IconVariantView newIcon = _companentsFactory.Get<IconVariantView>(item, _iconVariantViewParent);
            newIcon.Toogle.group = _toggleGroup;
            newIcon.Init(item);
            newIcon.Selected += SetIcon;
        }
    }

    private void SetIcon(IconVariantView view) {
        _icon = view.Config.Icon;
    }

    private void ApplyButtonClick() {
        if (_isIncom == false) {
            ExpenditureCategoryViewConfig viewConfig = new ExpenditureCategoryViewConfig(_nameInput.text, _icon);
            _categoryViewConfigs.AddExpenditureCategory(viewConfig);
        } else {
            IncomeCategoryViewConfig viewConfig = new IncomeCategoryViewConfig(_nameInput.text, _icon);
            _categoryViewConfigs.AddIncomeCategory(viewConfig);
        }
    }

    private void ClearButtonClick() {
        _nameInput.text = "";
        _icon = null;
    }

    private void SetExpenditureType(bool value) {
        if (value == false)
            return;

        _isIncom = false;
    }

    private void SetIncomType(bool value) {
        if (value == false)
            return;

        _isIncom = true;
    }

    public void Dispose() {
        _applyButton.onClick.RemoveListener(ApplyButtonClick);
        _clearButton.onClick.RemoveListener(ClearButtonClick);
    }
}
