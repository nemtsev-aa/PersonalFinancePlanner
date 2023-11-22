using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitcherWindowsPanel : UICompanent, IDisposable {
    public event Action<SwitcherWindowsPanel, SelectorView> ActiveSelectorChanged;

    private SelectorsWindowsPanelConfig _config;
    private List<SelectorView> _selectors;

    [field: SerializeField] public Image BackgroundImage { get; private set; }
    [field: SerializeField] public RectTransform SelectorsParent { get; private set; }

    public SelectorsWindowsPanelConfig Config => _config;

    public SelectorView ActiveSelector => _selectors.FirstOrDefault(selector => selector.Toggle.isOn == true);

    public void Init(SelectorsWindowsPanelConfig config, List<SelectorView> selectors) {
        _config = config;
        _selectors = selectors;

        ÑonfigureÑomponents();
    }

    private void ÑonfigureÑomponents() {
        name = $"{_config.Configs}";
        BackgroundImage.color = _config.BackgroundColor;

        foreach (var iSelector in _selectors) {
            iSelector.Toggle.onValueChanged.AddListener((value) => ActivateSelector(value, iSelector));
        }

        _selectors[0].IsActive = true;
    }

    private void ActivateSelector(bool value, SelectorView selector) {
        if (value == true)
            ActiveSelectorChanged?.Invoke(this, selector);
    }

    public void Dispose() {
        foreach (var iSelector in _selectors) {
            iSelector.Toggle.onValueChanged.RemoveListener((value) => ActivateSelector(value, iSelector));
        }
    }
}
