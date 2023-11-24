using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogSwitcherView : UICompanent, IDisposable {
    public event Action<SelectorView> ActiveSelectorChanged;

    [SerializeField] private RectTransform _selectorsParent;
    [SerializeField] private Button _hideView
        ;
    private SelectorViewConfigs _selectorViewConfigs;
    private UICompanentsFactory _companentsFactory;
    private List<SelectorView> _selectors;

    [field: SerializeField] public DialogSwitcherViewConfig Config { get; private set; }
    [field: SerializeField] public Image BackgroundImage { get; private set; }
    

    public void Init(SelectorViewConfigs selectorViewConfigs, UICompanentsFactory companentsFactory) {
        _selectorViewConfigs = selectorViewConfigs;
        _companentsFactory = companentsFactory;

        CrateSelectorViews();
        ÑonfigureÑomponents();
    }

    public void Show(bool status) => gameObject.SetActive(status);

    private void CrateSelectorViews() {
       _selectors = new List<SelectorView>();

        foreach (var iSelectorViewConfig in _selectorViewConfigs.Configs) {
            SelectorView newSelectorView = _companentsFactory.Get<SelectorView>(iSelectorViewConfig, _selectorsParent);
            newSelectorView.Init(iSelectorViewConfig, _selectorViewConfigs.HeaderColor);

            _selectors.Add(newSelectorView);
        }
    }

    private void ÑonfigureÑomponents() {
        BackgroundImage.color = Config.BackgroundColor;

        foreach (var iSelector in _selectors) {
            iSelector.Selected += OnSelected;
        }

        _selectors.ElementAt(0).IsActive = true;

        _hideView.onClick.AddListener(HideViewClick);
    }

    private void HideViewClick() => Show(false);

    private void OnSelected(SelectorView selector) {
        Show(false);
        ActiveSelectorChanged?.Invoke(selector);
    }

    public void Dispose() {
        foreach (var iSelector in _selectors) {
            iSelector.Selected -= OnSelected;
        }

        _hideView.onClick.RemoveListener(HideViewClick);
    }
}
