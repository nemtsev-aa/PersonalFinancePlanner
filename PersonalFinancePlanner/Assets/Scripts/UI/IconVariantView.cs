using System;
using UnityEngine;
using UnityEngine.UI;

public class IconVariantView : UICompanent, IDisposable {
    public event Action<IconVariantView> Selected;
    
    [field: SerializeField] public Toggle Toogle { get; private set; }
    [field: SerializeField] public Image Icon { get; private set; }
    public IconVariantViewConfig Config { get; private set; }

    public void Init(IconVariantViewConfig config) {
        Config = config;

        InstallCompanents();
        CreateSubscribers();
    }

    private void CreateSubscribers() {
        Toogle.onValueChanged.AddListener(Selection);
    }

    private void Selection(bool value) {
        if (value == false)
            return;

        Selected?.Invoke(this);
    }

    private void InstallCompanents() {
        Icon.sprite = Config.Icon;
    }

    public void Dispose() {
        Toogle.onValueChanged.RemoveListener(Selection);
    }
}
