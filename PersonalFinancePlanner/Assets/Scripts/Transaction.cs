public class Transaction {
    public TransactionData TransactionData { get; private set;}

    public Transaction(TransactionData transactionData) {
        TransactionData = transactionData;
    }

    public override string ToString() {
        return string.Format($"Описание: {TransactionData.Description}, Сумма: {TransactionData.Amount}, Категория: {TransactionData.Category.Name}");
    }
}
