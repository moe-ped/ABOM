using UnityEngine;
using System.Collections;
using System;

public class LogNode : Node 
{
    [VisualInputField]
    public StringObject Text = new StringObject();

    [VisualOutputField]
    public ActionObject Next = new ActionObject();

    public override void Activate()
    {
        base.Activate();
        if (Text.Text != "") 
        {
            Debug.Log(Text.Text);
        }
        try
        {
            Next.Action();
        }
        catch (Exception e)
        {
            //Debug.Log ("output not set up properly: " + e.Message);
        }
    }
}
