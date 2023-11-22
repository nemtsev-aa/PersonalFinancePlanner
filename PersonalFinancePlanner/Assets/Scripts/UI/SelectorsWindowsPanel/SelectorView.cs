using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectorView : UICompanent {
    public event Action<SelectorView> Selected;

    private SelectorViewConfig _config;
    private Color _headerColor;

    [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
    [field: SerializeField] public Image Icon { get; private set; }
    [field: SerializeField] public Button Selector { get; private set; }

public SelectorViewConfig Config => _config;
    public bool IsActive { get; set; } = false;

    public void Init(SelectorViewConfig config, Color headerColor) {
        _config = config;
        _headerColor = headerColor;

        ÑonfigureÑomponents();
    }

    private void ÑonfigureÑomponents() {
        Icon.sprite = _config.Icon;
        Name.text = _config.Name;

        Selector.onClick.AddListener(SelectorClick);
    }

    private void SelectorClick() => Selected?.Invoke(this);

}
