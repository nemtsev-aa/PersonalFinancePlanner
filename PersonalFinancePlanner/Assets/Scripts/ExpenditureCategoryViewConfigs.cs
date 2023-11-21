using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpenditureCategoryViewConfigs", menuName = "Config/ExpenditureCategoryViewConfigs")]
public class ExpenditureCategoryViewConfigs : ScriptableObject {
    [field: SerializeField] public List<ExpenditureCategoryViewConfig> Configs { get; private set; }

    public Sprite GetSpriteByCategoryName(string name) {
        return Configs.FirstOrDefault(config => config.Name == name).Icon;
    }

    public void AddCategory(ExpenditureCategoryViewConfig config) {
        Configs.Add(config);
    }
}
