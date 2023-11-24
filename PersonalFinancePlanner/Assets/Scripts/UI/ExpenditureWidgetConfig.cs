using System;

public class ExpenditureWidgetConfig : CategoryWidgetConfig {
    public event Action ExpenditureWidgetDataConfig;

    private ExpenditureCategoryViewConfig _categoryConfig;

    public ExpenditureWidgetConfig(ExpenditureCategoryViewConfig categoryConfig) : base(categoryConfig) {
        _categoryConfig = categoryConfig;
        SetData();

        _categoryConfig.ExpenditureDataChanged += OnExpenditureDataChanged;
    }

    public string Limit { get; private set; }
    public ExpenditureCategoryViewConfig CategoryViewConfig => _categoryConfig;
    
    private void SetData() {
        Name = _categoryConfig.Name;
        Limit = _categoryConfig.Limit.ToString();
        Value = _categoryConfig.Value.ToString();
        Icon = _categoryConfig.Icon;
    }

    private void OnExpenditureDataChanged() {
        SetData();
        ExpenditureWidgetDataConfig?.Invoke();
    }
}
