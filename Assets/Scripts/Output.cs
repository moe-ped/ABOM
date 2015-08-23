using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Output : Put, IDragHandler, IDropHandler
{
    public Node Parent;

    // The input this is connected to
    public Input Input;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        Input other = eventData.pointerDrag.GetComponent<Input>();
        if (other != null && other.Type == this.Type)
        {
            other.Output = this;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}