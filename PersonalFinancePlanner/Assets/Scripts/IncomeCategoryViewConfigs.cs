using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "IncomeCategoryConfigs", menuName = "Config/IncomeCategoryConfigs")]
public class IncomeCategoryViewConfigs : ScriptableObject {
    [field: SerializeField] public List<IncomeCategoryViewConfig> Configs { get; private set; }

    public Sprite GetSpriteByCategoryName(string name) {
        return Configs.FirstOrDefault(config => config.Name == name).Icon;
    }

    public void AddCategory(IncomeCategoryViewConfig config) {
        Configs.Add(config);
    }
}
