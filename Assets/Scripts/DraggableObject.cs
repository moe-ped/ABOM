using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IDragHandler, IBeginDragHandler 
{
    private Vector3 Offset;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + Offset;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Offset = transform.position - Input.mousePosition;
    }
}
