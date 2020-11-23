using UnityEngine;
using UnityEngine.EventSystems;


public class Slots : MonoBehaviour, IDropHandler
{
    public GameObject ItemtoSlot; // Item, который находится в данном Slot(е)

    private BehaviourSaitCases saitCase;

    private void Start()
    {
        saitCase = GetComponentInParent<BehaviourSaitCases>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.GetComponentInChildren<InformSlotItem>() == null && gameObject.GetComponentInChildren<MoveItemUI>() == null)
        {
            ItemtoSlot = null;
        }
        if (eventData.pointerDrag != null && ItemtoSlot == null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
            eventData.pointerDrag.GetComponent<IUpdateLastPosition>().LastPosition(new Vector2(0f, 0f));
            ItemtoSlot = eventData.pointerDrag.gameObject;
            saitCase.AddItem(eventData.pointerDrag.gameObject);
        }
    }
}