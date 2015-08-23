using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class NodeUI : MonoBehaviour 
{
    public Transform InputGroup;
    public GameObject InputPrefab;
    public Transform OutputGroup;
    public GameObject OutputPrefab;

    private Node Node;

	void Awake () 
    {
        Node = GetComponent<Node>();

        SetupUI();
	}

    private void SetupUI ()
    {
        Type type = Node.GetType();
        FieldInfo[] infos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        
        foreach (var info in infos)
        {
            // Spawn input pins
            if (info.FieldType == typeof(Input))
            {
                GameObject input = Instantiate(InputPrefab);
                input.transform.SetParent(InputGroup, false);

                Input inputComponent = input.GetComponent<Input>();
            }
            // Spawn output pins
            if (info.FieldType == typeof(Output))
            {
                GameObject input = Instantiate(InputPrefab);
                input.transform.SetParent(InputGroup, false);
            }
        }
    }
}
