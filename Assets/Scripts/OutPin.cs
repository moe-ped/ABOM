using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OutPin : MonoBehaviour, IDragHandler, IDropHandler
{
    public int Number;

    public Node Parent;

    void Awake ()
    {
        Parent = transform.parent.GetComponent<Node>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        InPin other = eventData.pointerDrag.GetComponent<InPin>();
        if (other != null)
        {
            Parent.NextNodes[Number] = other.Parent;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}