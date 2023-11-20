using System;

[Serializable]
public class TransactionViewConfig : UICompanentConfig {
    
    public TransactionViewConfig(Transaction transaction) {
        Transaction = transaction;
    }

    public Transaction Transaction { get; private set; }
    
    public override void OnValidate() {
        
    }
}
