using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IncomeWidgetView : CategoryWidgetView {
    public event Action<IncomeWidgetView> IncomeWidgetViewSelected;

    [SerializeField] private TextMeshProUGUI _targetText;
    
    public IncomeWidgetConfig Config { get; private set; }

    public void Init(IncomeWidgetConfig config, ToggleGroup group) {
        Config = config;
        FrameToggle.group = group;

        AddListeners();
        UpdateFilling();
    }

    public override void AddListeners() {
        base.AddListeners();
        Config.IncomeWidgetDataConfig += UpdateFilling;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();
        Config.IncomeWidgetDataConfig -= UpdateFilling;
    }

    public override void UpdateCompanents() {
        NameText.text = Config.Name;
        Icon.sprite = Config.Icon;
        ValueText.text = Config.Value;
        _targetText.text = Config.Target;
    }

    public override void UpdateFilling() {
        UpdateCompanents();

        float percent = float.Parse(Config.Value) / float.Parse(Config.Target); 
        if (percent < 1) {
            FillingImage.fillAmount = percent;
        } else {
            FillingImage.fillAmount = 1;
        } 
    }

    public override void FrameToggleClick(bool value) {
        if(value == true)
            IncomeWidgetViewSelected?.Invoke(this);
    }
}
