using UnityEngine;
using System;

[Serializable]
public class CategoryConfig {
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}
