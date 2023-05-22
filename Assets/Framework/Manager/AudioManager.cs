using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{

    public Dictionary<string,AudioClip> audioClipDic = new Dictionary<string,AudioClip>();
    private static readonly string audioTextPathPrefix = Application.dataPath + "\\Framework\\Resources\\";
    private static readonly string audioTextPathPostfix = "audiolist.txt";
    public static string AudioTextPath
    {
        get
        {
            return audioTextPathPrefix + audioTextPathPostfix;
        }
    }
    public AudioManager()
    {
        
    }

    private void LoadAudioClip()
    {
        audioClipDic = new Dictionary<string, AudioClip>();
        TextAsset ta = Resources.Load<TextAsset>(audioTextPathPostfix);
        string[] lines = ta.text.Split("\n");
        foreach(string line in lines)
        {
            if(string.IsNullOrEmpty(line)) continue;    
            string[] keyValue = line.Split(',');
            string key = keyValue[0];
            AudioClip value = Resources.Load<AudioClip>(keyValue[1]);   
            audioClipDic.Add(key, value);
        }
    }

    public void Play(string name)
    {
        AudioClip ac;
        audioClipDic.TryGetValue(name, out ac);
        if(ac != null)
        {
            AudioSource.PlayClipAtPoint(ac,Vector3.zero);
        }
    }

    public void Play(string name,Vector3 position)
    {
        AudioClip ac;
        audioClipDic.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }
}
