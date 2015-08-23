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
                    ActionObject otherActionObject = (ActionObject)other.Value;
                    ActionObject actionObject = (ActionObject)Value;
                    actionObject.Action = otherActionObject.Action;
                    break;
                case PinType.String:
                    StringObject otherStringObject = (StringObject)other.Value;
                    StringObject stringObject = (StringObject)Value;

                    string originalString = stringObject.Text;
                    Debug.Log(originalString);
                    stringObject = otherStringObject;
                    stringObject.Text = originalString;
                    break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}