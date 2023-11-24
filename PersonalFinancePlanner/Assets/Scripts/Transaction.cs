public class Transaction {

    public Transaction(TransactionData transactionData, string id) {
        TransactionData = transactionData;
        ID = id;
    }

    public TransactionData TransactionData { get; private set; }
    public string ID { get; private set; }

    public override string ToString() {
        return string.Format($"��������: {TransactionData.Description}, �����: {TransactionData.Amount}, ���������: {TransactionData.Category.CategoryData.Name}");
    }
}
