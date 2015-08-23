using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Input : Put, IDragHandler, IDropHandler
{
    public Node Parent;

    // The output this is connected to
    public Output Output;

    public Action<object> Action;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        Output other = eventData.pointerDrag.GetComponent<Output>();
        if (other != null)
        {
            other.Input = this;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
