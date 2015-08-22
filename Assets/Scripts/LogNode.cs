using UnityEngine;
using System.Collections;

public class LogNode : Node 
{
    public override void DoStuff()
    {
        base.DoStuff();
        Debug.Log("log log!");
    }
}
