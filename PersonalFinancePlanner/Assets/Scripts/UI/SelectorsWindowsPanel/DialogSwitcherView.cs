using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogSwitcherView : UICompanent, IDisposable {
    public event Action<SelectorView> ActiveSelectorChanged;

    private IEnumerable<SelectorView> _selectors;

    [field: SerializeField] public DialogSwitcherViewConfig Config { get; private set; }
    [field: SerializeField] public Image BackgroundImage { get; private set; }
    [field: SerializeField] public RectTransform SelectorsParent { get; private set; }

    public void Init(IEnumerable<SelectorView> selectors) {
        _selectors = selectors;

        —onfigure—omponents();
    }

    private void —onfigure—omponents() {
        BackgroundImage.color = Config.BackgroundColor;

        foreach (var iSelector in _selectors) {
            iSelector.Selected += OnSelected;
        }

        _selectors.ElementAt(0).IsActive = true;
    }

    private void OnSelected(SelectorView selector) {
        ActiveSelectorChanged?.Invoke(selector);
    }

    public void Dispose() {
        foreach (var iSelector in _selectors) {
            iSelector.Selected -= OnSelected;
        }
    }
}
