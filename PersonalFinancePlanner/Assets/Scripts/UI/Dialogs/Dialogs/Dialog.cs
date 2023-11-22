using System;
using UnityEngine;

public abstract class Dialog : MonoBehaviour, IDisposable {
    public event Action OnClosed;

    public virtual void Init() {
        AddListeners();

    }

    public virtual void Show(bool value) {
        gameObject.SetActive(value);
    }

    public virtual void Close() {
        OnClosed?.Invoke();
    }

    public abstract void AddListeners();

    public abstract void RemoveListeners();

    public void Dispose() {
        RemoveListeners();

    }
}