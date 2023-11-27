using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Transactions_SO", menuName = "Config/Transactions_SO")]
public class Transactions_SO : ScriptableObject {
    [SerializeField] private List<Transaction> _transactions;

    public IEnumerable<Transaction> Transactions => _transactions;

    public void Add(Transaction data) {
        _transactions.Add(data);
    }

    public void AddRange(List<Transaction> data) {
        foreach (var item in data) {
            _transactions.Add(item);
        }
    }

    public void Remove(Transaction data) {
        _transactions.Remove(data);
    }

    public void RemoveRange(List<Transaction> data) {
        foreach (var item in data) {
            _transactions.Remove(item);
        }
    }
}
