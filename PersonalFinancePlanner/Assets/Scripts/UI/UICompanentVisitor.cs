using System.Collections.Generic;
using System.Linq;

public class UICompanentVisitor : ICompanentVisitor {
    private readonly IEnumerable<UICompanent> _companents;

    public UICompanentVisitor(IEnumerable<UICompanent> companents) {
        _companents = companents;
    }

    public UICompanent Companent { get; private set; }

    public void Visit(UICompanentConfig companent) => Visit((dynamic)companent);

    public void Visit(TransactionViewConfig panel) => Companent = _companents.FirstOrDefault(companent => companent is TransactionView);
}