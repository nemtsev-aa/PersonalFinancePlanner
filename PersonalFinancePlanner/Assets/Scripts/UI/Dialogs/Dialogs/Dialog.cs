using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Dialog : MonoBehaviour, IDisposable {
    public event Action OnClosed;
    public event Action ShowDialogSwitcherSelected;

    [SerializeField] protected Button ShowDialogSwitcher;
    public bool IsInit { get; protected set; } = false;
    
    public virtual void Init() {
        AddListeners();
    }

    public virtual void Show(bool value) {
        gameObject.SetActive(value);
    }

    public virtual void Close() {
        Show(false);
        OnClosed?.Invoke();
    }

    public virtual void AddListeners() {
        ShowDialogSwitcher.onClick.AddListener(ShowDialogSwitcherClick);
    }

    public virtual void RemoveListeners() {
        ShowDialogSwitcher.onClick.RemoveListener(ShowDialogSwitcherClick);
    }

    private void ShowDialogSwitcherClick() => ShowDialogSwitcherSelected?.Invoke();
   
    public void Dispose() {
        RemoveListeners();
    }
}