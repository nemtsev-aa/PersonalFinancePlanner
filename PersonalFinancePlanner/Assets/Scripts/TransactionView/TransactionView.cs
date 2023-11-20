using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransactionView : MonoBehaviour {
    [field: SerializeField] public Image CategoryImage { get; private set; }
    [field: SerializeField] public TextMeshProUGUI DescriptionText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI AmountText { get; private set; }

    private Transaction _transaction;
    
    public void Init(Transaction transaction) {
        _transaction = transaction;

        UpdateCompanents();
    }

    private void UpdateCompanents() {
        CategoryImage.sprite = _transaction.Category.Icon;
        DescriptionText.text = _transaction.Description;
        AmountText.text = $"{ _transaction.Amount}";
    }
}
