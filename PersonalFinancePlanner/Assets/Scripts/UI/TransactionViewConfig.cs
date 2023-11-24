using System;

[Serializable]
public class TransactionViewConfig : UICompanentConfig {
    
    public TransactionViewConfig(Transaction transaction) {
        Transaction = transaction;
    }

    public TransactionViewConfig(TransactionData data) {
        Transaction = new Transaction(data, $"{data.Date}");
    }

    public Transaction Transaction { get; private set; }
    

    public override void OnValidate() {
        
    }
}
