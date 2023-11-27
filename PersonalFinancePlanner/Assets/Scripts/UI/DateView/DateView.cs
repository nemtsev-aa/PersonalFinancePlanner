using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateView : UICompanent, IDisposable {
    [SerializeField] private TextMeshProUGUI _dateText;
    [SerializeField] private Button _followDateButton;
    [SerializeField] private Button _yesterDateButton;

    private DateTime _currentDate;

    public DateTime CurrentDate => _currentDate;

    public void Init() {
        _currentDate = DateTime.Now;

        AddListeners();
        GetCurrentDate();
    }

    public void SetDate(DateTime dateTime) {
        _currentDate = dateTime;
        ShowDate();
    }

    public void Reset() {
        GetCurrentDate();
    }

    private void AddListeners() {
        _followDateButton.onClick.AddListener(FollowDateButtonClick);
        _yesterDateButton.onClick.AddListener(YesterDateButtonClick);
    }

    private void GetCurrentDate(int value = 0) {
        _currentDate = _currentDate.AddDays(value);

        ShowDate();
    }

    private void ShowDate() => _dateText.text = _currentDate.ToString("dd/MM/yyyy");

    private void FollowDateButtonClick() => GetCurrentDate(1);

    private void YesterDateButtonClick() => GetCurrentDate(-1);

    public void Dispose() {
        _followDateButton.onClick.RemoveListener(FollowDateButtonClick);
        _yesterDateButton.onClick.RemoveListener(YesterDateButtonClick);
    }
}
