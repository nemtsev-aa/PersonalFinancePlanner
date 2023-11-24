using UnityEngine;

public class CategoryWidgetPanelView : MonoBehaviour {
    [field: SerializeField] public RectTransform Parent { get; private set; }
    [field: SerializeField, Range(2,5)] public int MaxSlotCount { get; private set; }
    public int FreeSlotCount { get; private set; }

    public void Init() {
        FreeSlotCount = MaxSlotCount;
    }

    public void TakeSlot() {
        FreeSlotCount -= 1;
    }
}
