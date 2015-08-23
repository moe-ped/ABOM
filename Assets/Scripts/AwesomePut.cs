using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AwesomePut : MonoBehaviour 
{
    [SerializeField]
    private Text Label;

    public string Name
    {
        get
        {
            return Label.text;
        }
        set
        {
            Label.text = value;
        }
    }

    public enum PinType { Action, Number, String };
    public PinType Type;
}
