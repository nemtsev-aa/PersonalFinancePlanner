using System;

public class IncomeWidgetConfig : CategoryWidgetConfig {
    public event Action IncomeWidgetDataConfig;

    private IncomeCategoryViewConfig _categoryConfig;
    
    public IncomeWidgetConfig(IncomeCategoryViewConfig categoryConfig) : base(categoryConfig) {
        _categoryConfig = categoryConfig;
        SetData();
        _categoryConfig.IncomeDataChanged += OnIncomeDataChanged;
    }

    public string Target { get; private set; }
    public IncomeCategoryViewConfig CategoryConfig => _categoryConfig;
    
    private void SetData() {
        Name = _categoryConfig.Name;
        Target = _categoryConfig.Target.ToString();
        Value = _categoryConfig.Value.ToString();
        Icon = _categoryConfig.Icon;
    }

    private void OnIncomeDataChanged() {
        SetData();
        IncomeWidgetDataConfig?.Invoke();
    }
}
