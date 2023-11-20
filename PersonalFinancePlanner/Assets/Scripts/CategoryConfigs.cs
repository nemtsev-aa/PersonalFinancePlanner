using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CategoryConfigs", menuName = "Config/CategoryConfigs")]
public class CategoryConfigs : ScriptableObject {
    [field: SerializeField] public List<CategoryConfig> Configs { get; private set; }

    public Sprite GetSpriteByCategoryName(string name) {
        return Configs.FirstOrDefault(config => config.Name == name).Icon;
    }
}
