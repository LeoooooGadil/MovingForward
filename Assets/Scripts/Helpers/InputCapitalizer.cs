using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputCapitalizer : MonoBehaviour
{
    TMP_InputField inputField;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onValueChanged.AddListener(delegate { Capitalize(); });
    }

    public void Capitalize()
    {
        if (inputField.text.Length > 0)
        inputField.text = inputField.text.Substring(0, 1).ToUpper() + inputField.text.Substring(1);
    }
}
