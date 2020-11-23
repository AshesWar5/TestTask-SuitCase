using UnityEngine;

using UnityEngine.EventSystems;

public class BaseItems : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
            eventData.pointerDrag.GetComponent<IUpdateLastPosition>().LastPosition(new Vector2(0f, 0f));
        }
    }
}