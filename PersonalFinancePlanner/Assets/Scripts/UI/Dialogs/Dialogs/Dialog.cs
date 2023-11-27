using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class Dialog : MonoBehaviour, IDisposable {
    public event Action OnClosed;
    public event Action ShowDialogSwitcherSelected;

    [SerializeField] protected Button ShowDialogSwitcher;
    [SerializeField] protected List<UIPanel> Panels = new List<UIPanel>();

    protected DialogMediator Mediator;

    public bool IsInit { get; protected set; } = false;
    
    public virtual void Init(DialogMediator mediator) {
        Mediator = mediator;

        AddListeners();
    }

    public virtual void Show(bool value) {
        gameObject.SetActive(value);
    }

    public virtual void ShowPanel<T>(bool value) where T : UIPanel {
        T panel = (T)Panels.First(panel => panel is T);

        panel.UpdateContent();
        panel.Show(value);
    }

    public virtual void Close() {
        gameObject.SetActive(false);
        OnClosed?.Invoke();
    }

    public virtual void AddListeners() {
        ShowDialogSwitcher.onClick.AddListener(ShowDialogSwitcherClick);
    }

    public virtual void RemoveListeners() {
        ShowDialogSwitcher.onClick.RemoveListener(ShowDialogSwitcherClick);
    }

    public virtual T GetPanelByType<T>() where T : UIPanel {
        return (T)Panels.FirstOrDefault(panel => panel is T);
    }

    private void ShowDialogSwitcherClick() => ShowDialogSwitcherSelected?.Invoke();
   
    public void Dispose() {
        RemoveListeners();
    }
}