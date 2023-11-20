public class Transaction {
    public TransactionData TransactionData { get; private set;}

    public Transaction(TransactionData transactionData) {
        TransactionData = transactionData;
    }

    public override string ToString() {
        return string.Format($"��������: {TransactionData.Description}, �����: {TransactionData.Amount}, ���������: {TransactionData.Category.Name}");
    }
}
