using UnityEngine;
using System.Collections;

public class StartNode : Node 
{
    void Awake ()
    {
        NextNodes = new Node[1];
    }

	void Update () 
    {
        if (NextNodes[0] != null)
        {
            NextNodes[0].DoStuff();
        }
	}
}
