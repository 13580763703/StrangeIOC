using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager
{
    private static LocalizationManager _instance;
    public static LocalizationManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";
     
    public const string Language = English;

    private Dictionary<string, string> dict;
    public LocalizationManager()
    {
        dict = new Dictionary<string, string>();
        TextAsset ta = Resources.Load<TextAsset>(Language);
        if (ta == null) return;
        string[] Lines = ta.text.Split('\n');
        foreach (string line in Lines)
        {
            if (string.IsNullOrEmpty(line)==false)
            {
                string[] keyValues = line.Split('=');
                dict.Add(keyValues[0], keyValues[1]);
            }  
        }
    }

    public void Init()
    {
        //do nothing 
    }

    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
