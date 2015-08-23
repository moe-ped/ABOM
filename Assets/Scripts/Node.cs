using UnityEngine;
using System.Collections;
using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class VisualMethod : System.Attribute
{
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class VisualInputField : System.Attribute
{
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class VisualOutputField : System.Attribute
{
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class VisualTextUserInputField : System.Attribute
{
}

// Gaaah!!!
public class StringObject
{
    public string Text;

    public StringObject()
    {
        Text = "";
    }

    public StringObject(string text)
    {
        Text = text;
    }
}

public class ActionObject
{
    public Action Action;

    public ActionObject()
    {
        Action Action = () => { };
    }

    public ActionObject(Action action)
    {
        Action Action = action;
    }
}

public abstract class Node : MonoBehaviour 
{
    public Brain Brain;

    [VisualMethod]
	public virtual void Activate ()
    {

    }
}
