using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour 
{
    public Unit Unit;

	void Awake () 
    {
        Node[] nodes = GetComponentsInChildren<Node>();
	    foreach (var node in nodes)
        {
            node.Brain = this;
        }
	}
}
