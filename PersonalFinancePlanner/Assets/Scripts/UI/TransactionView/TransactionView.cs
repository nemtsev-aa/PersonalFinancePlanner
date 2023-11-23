using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransactionView : UICompanent {
    [field: SerializeField] public Image CategoryImage { get; private set; }
    [field: SerializeField] public TextMeshProUGUI DescriptionText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI AmountText { get; private set; }

    public TransactionViewConfig Config { get; private set; }

    public void Init(TransactionViewConfig config) {
        Config = config;

        UpdateCompanents();
    }

    private void UpdateCompanents() {
        TransactionData transaction = Config.Transaction.TransactionData;

        CategoryImage.sprite = transaction.Category.CategoryData.Icon;
        DescriptionText.text = transaction.Description;
        AmountText.text = $"{ transaction.Amount}";
    }
}
