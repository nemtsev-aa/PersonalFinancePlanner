using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField] private SelectorViewConfigs _selectorViewConfigs;
    [SerializeField] private DialogFactory _dialogFactory;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    [SerializeField] private RectTransform _dialogsParent;
    [SerializeField] private DialogSwitcherView _switcherView;

    private DialogSwitcher _dialogSwitcher;

    private void Start() {
        _dialogSwitcher = new DialogSwitcher(_dialogFactory, _dialogsParent);
        List<SelectorView> selectors = CrateSelectorViews();
        _switcherView.Init(selectors);
        _switcherView.ActiveSelectorChanged += OnActiveDialogSelectorChanged;
    }

    private List<SelectorView> CrateSelectorViews() {
        List<SelectorView> selectors = new List<SelectorView>();

        foreach (var iSelectorViewConfig in _selectorViewConfigs.Configs) {
            SelectorView newSelectorView = _companentsFactory.Get<SelectorView>(iSelectorViewConfig, _switcherView.SelectorsParent);
            newSelectorView.Init(iSelectorViewConfig, _selectorViewConfigs.HeaderColor);

            selectors.Add(newSelectorView);
        }

        return selectors;
    }

    private void OnActiveDialogSelectorChanged(SelectorView selector) {
        _dialogSwitcher.ShowDialog(selector.Config.Type);
    }
}
