using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransactionView : UICompanent, IDisposable {
    public event Action<TransactionView> TransactionViewSelected;
    [field: SerializeField] public Image CategoryImage { get; private set; }
    [field: SerializeField] public Toggle Toggle { get; set; }
    [field: SerializeField] public TextMeshProUGUI DescriptionText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI AmountText { get; private set; }

    public TransactionViewConfig Config { get; private set; }

    public void Init(TransactionViewConfig config) {
        Config = config;

        AddListeners();
        UpdateCompanents();
    }

    private void AddListeners() {
        Toggle.onValueChanged.AddListener(ToggleValueChanged);
    }

    private void RemoveListeners() {
        Toggle.onValueChanged.RemoveListener(ToggleValueChanged);
    }

    private void UpdateCompanents() {
        TransactionData transaction = Config.Transaction.Data;

        CategoryImage.sprite = transaction.Category.CategoryData.Icon;
        DescriptionText.text = transaction.Description;
        AmountText.text = $"{ transaction.Amount}";
    }

    private void ToggleValueChanged(bool value) {
        if (value)
            TransactionViewSelected?.Invoke(this);
    }

    public void Dispose() {
        RemoveListeners();
    }
}
