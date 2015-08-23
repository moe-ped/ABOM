using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour 
{
    public Transform InputGroup;
    public GameObject InputPrefab;
    public Transform OutputGroup;
    public GameObject OutputPrefab;
    public Transform BodyGroup;
    public GameObject TextUserInputPrefab;
    public GameObject NamePrefab;

    private Node Node;

	void Awake () 
    {
        Node = GetComponent<Node>();

        SetupUI();
	}

    private void SetupUI ()
    {
        Type type = Node.GetType();

        // Spawn name label
        GameObject name = Instantiate(NamePrefab);
        name.transform.SetParent(BodyGroup, false);
        Text text = name.GetComponent<Text>();
        text.text = type.Name;

        MethodInfo[] methodInfos = type.GetMethods ();
        foreach (var methodInfo in methodInfos)
        {
            // Spawn input pins
            if (methodInfo.GetCustomAttributes(typeof(VisualMethod), true).Length > 0)
            {
                //Debug.Log(methodInfo.ReturnType + " input field " + methodInfo.Name);
                GameObject input = Instantiate(InputPrefab);
                input.transform.SetParent(InputGroup, false);

                AwesomeInput inputComponent = input.GetComponent<AwesomeInput>();
                //RuntimeMethodHandle handle = methodInfo.MethodHandle;
                ActionObject actionObject = new ActionObject();
                //actionObject.Action = () => { methodInfo.Invoke(Node, null); };
                actionObject.Action = (Action) Action.CreateDelegate(typeof(Action), Node, methodInfo);
                //actionObject.Action();
                inputComponent.Value = actionObject;
                inputComponent.Name = methodInfo.Name;
                inputComponent.Type = AwesomePut.PinType.Action;
            }
        }

        FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        foreach (var fieldInfo in fieldInfos)
        {
            // Spawn input fields
            if (fieldInfo.GetCustomAttributes(typeof(VisualTextUserInputField), true).Length > 0)
            {
                GameObject textUserInput = Instantiate(TextUserInputPrefab);
                textUserInput.transform.SetParent(BodyGroup, false);
                InputField inputField = textUserInput.GetComponentInChildren<InputField>();
                inputField.text = "test";
            }

            // Spawn input pins
            if (fieldInfo.GetCustomAttributes(typeof(VisualInputField), true).Length > 0)
            {
                //Debug.Log(fieldInfo.FieldType + " input field " + fieldInfo.Name);
                GameObject input = Instantiate(InputPrefab);
                input.transform.SetParent(InputGroup, false);

                AwesomeInput inputComponent = input.GetComponent<AwesomeInput>();
                inputComponent.Value = fieldInfo.GetValue(Node);
                inputComponent.Name = fieldInfo.Name;
                //Debug.Log(inputComponent.Value.ToString());
                switch (fieldInfo.FieldType.ToString())
                {
                    case "StringObject":
                        inputComponent.Type = AwesomePut.PinType.String;
                        break;
                    case "Float":
                        inputComponent.Type = AwesomePut.PinType.Number;
                        break;
                    case "Int":
                        inputComponent.Type = AwesomePut.PinType.Number;
                        break;
                }
            }
            // Spawn output pins
            if (fieldInfo.GetCustomAttributes(typeof(VisualOutputField), true).Length > 0 || 
                fieldInfo.GetCustomAttributes(typeof(VisualTextUserInputField), true).Length > 0)
            {
                //Debug.Log(fieldInfo.FieldType + " output field " + fieldInfo.Name);
                GameObject output = Instantiate(OutputPrefab);
                output.transform.SetParent(OutputGroup, false);

                AwesomeOutput outputComponent = output.GetComponent<AwesomeOutput>();
                outputComponent.Value = fieldInfo.GetValue(Node);
                outputComponent.Name = fieldInfo.Name;
                //Debug.Log(outputComponent.Value.ToString());
                switch (fieldInfo.FieldType.ToString())
                {
                    case "StringObject":
                        StringObject stringObject = (StringObject)outputComponent.Value;
                        Debug.Log(stringObject.Text);
                        outputComponent.Type = AwesomePut.PinType.String;
                        break;
                    case "Float":
                        outputComponent.Type = AwesomePut.PinType.Number;
                        break;
                    case "Int":
                        outputComponent.Type = AwesomePut.PinType.Number;
                        break;
                    case "ActionObject":
                        outputComponent.Type = AwesomePut.PinType.Action;
                        break;
                    case "InputField":
                        outputComponent.Value = outputComponent.GetComponentInChildren<InputField>();
                        outputComponent.Type = AwesomePut.PinType.TextInput;
                        break;
                }
            }
        }
    }
}
