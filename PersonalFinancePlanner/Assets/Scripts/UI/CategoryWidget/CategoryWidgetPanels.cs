using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CategoryWidgetPanels : MonoBehaviour {
    public event Action<IncomeCategoryViewConfig> IncomeWidgetSelected;
    public event Action<IncomeCategoryViewConfig> ExpenditureWidgetSelected;

    [SerializeField] private CategoryViewConfigs _configs;
    [SerializeField] private UICompanentsFactory _companentFactory;
    [SerializeField] private List<CategoryWidgetPanelView> _widgetPanels;
    [SerializeField] private ToggleGroup _toggleGroup;

    private List<CategoryWidgetView> _widgets;
    
    public IEnumerable<CategoryWidgetView> Widgets => _widgets;

    public void Init() {
        CreateWidgets();
    }

    private void CreateWidgets() {
        _widgets = new List<CategoryWidgetView>();

        WidgetPanelsInitialization();

        CreateIncomeCategoryWidgets();
        CreateExpenditureCategoryWidgets();
    }

    private void WidgetPanelsInitialization() {
        foreach (var iPanel in _widgetPanels) {
            iPanel.Init();
        }
    }

    private void CreateIncomeCategoryWidgets() {
        foreach (var iConfig in _configs.IncomeCategory.Configs) {
            CreateWidgetsFromPanel(GetFreeWidgetPanel(), iConfig);
        }
    }

    private void CreateExpenditureCategoryWidgets() {
        CategoryWidgetPanelView panel;

        foreach (var iConfig in _configs.ExpenditureCategory.Configs) {
            panel = GetFreeWidgetPanel();

            if (panel != null)
                CreateWidgetsFromPanel(panel, iConfig);
        }
    }

    private void CreateWidgetsFromPanel(CategoryWidgetPanelView iPanel, CategoryViewConfig config) {
        if (config is IncomeCategoryViewConfig) {
            IncomeWidgetConfig widgetConfig = new IncomeWidgetConfig((IncomeCategoryViewConfig)config);
            IncomeWidgetView widget = _companentFactory.Get<IncomeWidgetView>(widgetConfig, iPanel.Parent);
            widget.Init(widgetConfig, _toggleGroup);

            _widgets.Add(widget);

            iPanel.TakeSlot();
        }
        else {
            ExpenditureWidgetConfig widgetConfig = new ExpenditureWidgetConfig((ExpenditureCategoryViewConfig)config);
            ExpenditureWidgetView widget = _companentFactory.Get<ExpenditureWidgetView>(widgetConfig, iPanel.Parent);
            widget.Init(widgetConfig, _toggleGroup);

            _widgets.Add(widget);

            iPanel.TakeSlot();
        }
    }

    private CategoryWidgetPanelView GetFreeWidgetPanel() {
        var panels = _widgetPanels.Where(panel => panel.FreeSlotCount > 0);

        if (panels.Count() == 0) {
            return null;
        }
        else {
            return panels.ElementAt(0);
        }
    }
}
