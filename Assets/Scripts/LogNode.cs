﻿using UnityEngine;
using System.Collections;

public class LogNode : Node 
{
    private Input ActionInput;

    public override void DoStuff()
    {
        base.DoStuff();
        Debug.Log("log log!");
    }
}
