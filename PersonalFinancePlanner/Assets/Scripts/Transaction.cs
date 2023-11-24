public class Transaction {

    public Transaction(TransactionData transactionData, string id) {
        TransactionData = transactionData;
        ID = id;
    }

    public TransactionData TransactionData { get; private set; }
    public string ID { get; private set; }

    public override string ToString() {
        return string.Format($"Описание: {TransactionData.Description}, Сумма: {TransactionData.Amount}, Категория: {TransactionData.Category.CategoryData.Name}");
    }
}
