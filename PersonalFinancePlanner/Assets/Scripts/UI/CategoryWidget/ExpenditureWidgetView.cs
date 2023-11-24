using System;
using TMPro;
using UnityEngine;

public class ExpenditureWidgetView : CategoryWidgetView {
    public event Action<ExpenditureWidgetView> ExpenditureWidgetViewSelected;

    [SerializeField] private TextMeshProUGUI _limitText;
    public ExpenditureWidgetConfig Config { get; private set; }

    public void Init(ExpenditureWidgetConfig config, UnityEngine.UI.ToggleGroup group) {
        Config = config;
        FrameToggle.group = group;

        AddListeners();
        UpdateFilling();
    }

    public override void AddListeners() {
        base.AddListeners();
        Config.ExpenditureWidgetDataConfig += UpdateFilling;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();
        Config.ExpenditureWidgetDataConfig -= UpdateFilling;
    }

    public override void FrameToggleClick(bool value) {
        if (value == true)
            ExpenditureWidgetViewSelected?.Invoke(this);
    }

    public override void UpdateCompanents() {
        NameText.text = Config.Name;
        Icon.sprite = Config.Icon;
        ValueText.text = Config.Value;
        _limitText.text = Config.Limit;
    }

    public override void UpdateFilling() {
        UpdateCompanents();

        float percent = float.Parse(Config.Value) / float.Parse(Config.Limit);
        if (percent < 1) {
            FillingImage.fillAmount = percent;
        }
        else {
            FillingImage.fillAmount = 1;
        }
    }
}
