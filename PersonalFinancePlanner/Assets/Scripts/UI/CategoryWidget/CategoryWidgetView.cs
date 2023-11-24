using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CategoryWidgetView : UICompanent {
    [SerializeField] protected TextMeshProUGUI NameText;
    [SerializeField] protected TextMeshProUGUI ValueText;
    [SerializeField] protected Toggle FrameToggle;

    [SerializeField] protected Image Icon;
    [SerializeField] protected Image FillingImage;

    public virtual void AddListeners() {
        FrameToggle.onValueChanged.AddListener(FrameToggleClick);
    }

    public virtual void RemoveListeners() {
        FrameToggle.onValueChanged.RemoveListener(FrameToggleClick);
    }

    public abstract void FrameToggleClick(bool value);

    public abstract void UpdateCompanents();

    public abstract void UpdateFilling();
}
