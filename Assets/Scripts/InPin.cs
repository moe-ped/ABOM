using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InPin : MonoBehaviour, IDragHandler, IDropHandler
{
    public Node Parent;

    void Awake()
    {
        Parent = transform.parent.GetComponent<Node>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        OutPin other = eventData.pointerDrag.GetComponent<OutPin>();
        if (other != null)
        {
            other.Parent.NextNodes[other.Number] = Parent;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
