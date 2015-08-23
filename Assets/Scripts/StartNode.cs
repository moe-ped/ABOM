using UnityEngine;
using System.Collections;
using System;

public class StartNode : Node 
{
    [VisualOutputField]
    public ActionObject Next = new ActionObject();

    // Test
    void Start ()
    {
    }

    void Update ()
    {
        if (Next != null)
        {
            Next.Action();
        }
    }
}
