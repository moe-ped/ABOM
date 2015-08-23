using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class AwesomeInput : AwesomePut, IDragHandler, IDropHandler, IPointerClickHandler
{
    public object Value;

    // The output this is connected to
    public AwesomeOutput Output;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop, " + Value.ToString());
        AwesomeOutput other = eventData.pointerDrag.GetComponent<AwesomeOutput>();
        if (other != null)
        {
            if (Output != null)
            {
                Output.Value = null;
                Output.Input = null;
            }

            Output = other;
            other.Input = this;
            switch (Type)
            {
                case PinType.Action:
                    ActionObject otherActionObject = (ActionObject)other.Value;
                    ActionObject actionObject = (ActionObject)Value;
                    otherActionObject.Action = actionObject.Action;
                    break;
                case PinType.String:
                    StringObject otherStringObject = (StringObject)other.Value;
                    StringObject stringObject = (StringObject)Value;

                    string originalString = otherStringObject.Text;
                    Debug.Log(originalString);
                    otherStringObject = stringObject;
                    otherStringObject.Text = originalString;
                    break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (Type)
        {
            case PinType.Action:
                Debug.Log("Action!");

                ActionObject actionObject = (ActionObject)Value;
                actionObject.Action();

                break;
        }
    }
}
