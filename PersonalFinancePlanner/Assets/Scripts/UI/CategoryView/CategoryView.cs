using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryView : UICompanent {
    public event Action<CategoryView> Selected;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] public Image _icon;
    
    public CategoryViewConfig Config { get; private set; }
    
    public void Init(CategoryViewConfig config) {
        Config = config;

        InstallComponents();
    }

    private void InstallComponents() {
        _nameText.text = Config.Name;
        _icon.sprite = Config.Icon;
    }

    private void OnMouseDown() {
        Selected?.Invoke(this);
    }
}
