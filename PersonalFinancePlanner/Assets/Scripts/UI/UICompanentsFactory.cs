using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UICompanentsFactory", menuName = "Factory/UICompanentsFactory")]
public class UICompanentsFactory : ScriptableObject {
    [SerializeField] private List<UICompanent> _companents;

    private UICompanentVisitor _visitor;

    private UICompanent Companent => _visitor.Companent;

    public void Init() {
        _visitor = new UICompanentVisitor(_companents);
    }

    public T Get<T>(UICompanentConfig companent, RectTransform parent) where T : UICompanent {
        _visitor.Visit(companent);

        return (T)Instantiate(Companent, parent);
    }
}
