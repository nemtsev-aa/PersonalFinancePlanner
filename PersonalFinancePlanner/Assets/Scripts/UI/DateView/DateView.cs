using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateView : MonoBehaviour, IDisposable {
    [SerializeField] private TextMeshProUGUI _dateText;
    [SerializeField] private Button _followDateButton;
    [SerializeField] private Button _yesterDateButton;

    private DateTime _currentDate;

    public void Init() {
        AddListeners();

        GetCurrentDate();
    }

    public void Reset() {
        GetCurrentDate();
    }

    private void AddListeners() {
        _followDateButton.onClick.AddListener(FollowDateButtonClick);
        _yesterDateButton.onClick.AddListener(YesterDateButtonClick);
    }

    private void GetCurrentDate(double value = 0) {
        _currentDate = DateTime.Now;
        _currentDate.AddDays(value);

        ShowDate();
    }

    private void ShowDate() => _dateText.text = _currentDate.ToString("MM/dd/yyyy");

    private void FollowDateButtonClick() => GetCurrentDate(1);

    private void YesterDateButtonClick() => GetCurrentDate(-1);

    public void Dispose() {
        _followDateButton.onClick.RemoveListener(FollowDateButtonClick);
        _yesterDateButton.onClick.RemoveListener(YesterDateButtonClick);
    }
}
