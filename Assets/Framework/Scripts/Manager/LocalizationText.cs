using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour
{
    public string key;

    void Start()
    {
        string value = LocalizationManager.Instance.GetValue(key);
        if (string.IsNullOrEmpty(value))
            Debug.Log("value is null");
        GetComponent<TMP_Text>().text = value;
    }
}
