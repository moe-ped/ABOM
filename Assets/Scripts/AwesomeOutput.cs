using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class AwesomeOutput : AwesomePut, IDragHandler, IDropHandler
{
    public object Value;

    // The input this is connected to
    public AwesomeInput Input;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop, " + Value.ToString());
        AwesomeInput other = eventData.pointerDrag.GetComponent<AwesomeInput>();
        if (other != null && other.Type == this.Type)
        {
            if (Input != null)
            {
                Input.Output = null;
            }

            Input = other;
            other.Output = this;
            switch (Type)
            {
                case PinType.Action:
                    // Test
                    Debug.Log("Action!");
                    ActionObject otherActionObject = (ActionObject)Value;
                    ActionObject actionObject = (ActionObject)Value;

                    actionObject.Action = otherActionObject.Action;
                    actionObject.Action();
                    break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}