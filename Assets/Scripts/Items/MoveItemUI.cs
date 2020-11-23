using UnityEngine;

using UnityEngine.EventSystems;

public class MoveItemUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IUpdateLastPosition
{

    private RectTransform itemPosition;
    private Vector2 lastPosition;
    private CanvasGroup canvasGroup;
    
    private void Start()
    {
        itemPosition = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastPosition = itemPosition.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemPosition.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        itemPosition.anchoredPosition = lastPosition;
    }

    public void LastPosition(Vector2 position)
    {
            lastPosition = position;
    }
}
