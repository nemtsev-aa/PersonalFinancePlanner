using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectorViewConfigs", menuName = "Config/SelectorViewConfigs")]
public class SelectorViewConfigs : ScriptableObject {
    [field: SerializeField] public List<SelectorViewConfig> Configs { get; private set; }
}
