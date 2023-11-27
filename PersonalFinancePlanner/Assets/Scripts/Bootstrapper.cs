using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private CategoryViewConfigs _categoryViewConfigs;
    [SerializeField] private SelectorViewConfigs _selectorViewConfigs;
    [SerializeField] private Transactions_SO _transactions_SO;
    
    [SerializeField] private DialogFactory _dialogFactory;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    private ReadableTextures _readableTextures;
    private DialogMediator _dialogMediator;
    private DialogSwitcher _dialogSwitcher;
    private TransactionManager _transactionManager;
    private CategoryManager _categoryManager;

    [field: SerializeField] public UIManager UIManager { get; private set; }

    private void Start() {
        _transactionManager = new TransactionManager(_transactions_SO);
        _dialogSwitcher = new DialogSwitcher(_dialogFactory, UIManager.DialogsParent, UIManager.SwitcherView);
        _categoryManager = new CategoryManager(_categoryViewConfigs);
        _dialogMediator = new DialogMediator(_dialogSwitcher, _transactionManager, _categoryManager);
             
        UIManager.Init(_selectorViewConfigs, _companentsFactory, _dialogSwitcher, _dialogMediator);
    }
}
