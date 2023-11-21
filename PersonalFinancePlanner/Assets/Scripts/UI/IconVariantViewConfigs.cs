using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IconVariantViewConfigs", menuName = "Config/IconVariantViewConfigs")]
public class IconVariantViewConfigs : ScriptableObject {
    [field: SerializeField] public List<IconVariantViewConfig> Configs { get; private set; }
    
}
