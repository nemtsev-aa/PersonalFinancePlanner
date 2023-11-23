using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CategoryView : UICompanent, IPointerClickHandler {
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

    public void OnPointerClick(PointerEventData eventData) => Selected?.Invoke(this);
}
