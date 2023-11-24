using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TransactionDataList", menuName = "Config/TransactionDataList")]
public class TransactionDataList : ScriptableObject {
    [SerializeField] private List<TransactionData> _transactionDataList;

    public IEnumerable<TransactionData> List => _transactionDataList;

    public void Add(TransactionData data) {
        _transactionDataList.Add(data);
    }

    public void Remove(TransactionData data) {
        _transactionDataList.Remove(data);
    }

    public List<TransactionData> GetTransactionsByCategoryName(string name) {
        return _transactionDataList.Where(tName => tName.Category.CategoryData.Name == name).ToList();
    }

    public List<TransactionData> GetTransactionsByDate(DateTime date) {
        return _transactionDataList.Where(tName => tName.Date == date).ToList();
    }
}
