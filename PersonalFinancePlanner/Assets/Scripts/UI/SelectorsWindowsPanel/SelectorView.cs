using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectorView : UICompanent {
    public event Action<SelectorView> MouseDown;

    private SelectorViewConfig _config;
    private Color _headerColor;
    private Sprite _frame;

    [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
    [field: SerializeField] public Toggle Toggle { get; private set; }
    [field: SerializeField] public Image Icon { get; private set; }
    [field: SerializeField] public Image Frame { get; private set; }
   
    public SelectorViewConfig Config => _config;
    public bool IsActive { get; set; } = false;

    public void Init(SelectorViewConfig config, Color headerColor, Sprite frame) {
        _config = config;
        _headerColor = headerColor;
        _frame = frame;

        —onfigure—omponents();
    }

    private void —onfigure—omponents() {
        Icon.sprite = _config.Icon;
        Frame.sprite = _frame;
        Frame.color = _headerColor;
        Toggle.group = transform.parent.GetComponent<ToggleGroup>();
        Name.text = _config.Name;
    }

    private void OnMouseDown() {
        IsActive = true;
        MouseDown?.Invoke(this);
    }
}
