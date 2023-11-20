using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransactionView : UICompanent {
    [field: SerializeField] public Image CategoryImage { get; private set; }
    [field: SerializeField] public TextMeshProUGUI DescriptionText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI AmountText { get; private set; }

    private TransactionViewConfig _config;
    
    public void Init(TransactionViewConfig config) {
        _config = config;

        UpdateCompanents();
    }

    private void UpdateCompanents() {
        TransactionData transaction = _config.Transaction.TransactionData;

        CategoryImage.sprite = transaction.Category.Icon;
        DescriptionText.text = transaction.Description;
        AmountText.text = $"{ transaction.Amount}";
    }
}
