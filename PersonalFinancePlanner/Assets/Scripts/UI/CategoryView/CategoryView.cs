using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryView : UICompanent, IDisposable  {
    public event Action<CategoryView> Selected;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] public Image _icon;
    [SerializeField] public Toggle _toggle;
    
    public CategoryViewConfig Config { get; private set; }
    
    public void Init(CategoryViewConfig config) {
        Config = config;

        InstallComponents();
        AddListeners();
    }

    public void SetToggleGroup(ToggleGroup group) {
        _toggle.group = group;
    }

    public void SetCategoryData(CategoryData data) {
        _nameText.text = data.Name;
        _icon.sprite = data.Icon;
        _toggle.isOn = false;
    }

    private void InstallComponents() {
        _nameText.text = Config.Name;
        _icon.sprite = Config.Icon;
        _toggle.isOn = false;
    }

    public void AddListeners() {
        _toggle.onValueChanged.AddListener(ToggleValueChanged);
    }

    public void RemoveListeners() {
        _toggle.onValueChanged.RemoveListener(ToggleValueChanged);
    }

    private void ToggleValueChanged(bool value) {
        if (true)
            Selected?.Invoke(this);
    }

    public void Dispose() {
        RemoveListeners();
    }
}
