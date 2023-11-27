using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IconVariantViewConfigs", menuName = "Config/IconVariantViewConfigs")]
public class IconVariantViewConfigs : ScriptableObject {
    [field: SerializeField] public List<IconVariantViewConfig> Configs { get; private set; }
    
    public List<Sprite> GetSprites() {
        List<Sprite> sprites = new List<Sprite>();

        foreach (var item in Configs) {
            sprites.Add(item.Icon);
        }

        return sprites;
    }
}
