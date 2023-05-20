using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
/// <summary>
/// 音效管理面板
/// </summary>
public class AudioWindowEditor : EditorWindow
{
    [MenuItem("Manager/AudioManager")]
    static void CreateWindow() {
        //Rect rect = new Rect(400,400,400,400);
        //AudioWindowEditor window = EditorWindow.GetWindowWithRect(typeof(AudioWindowEditor),rect) as AudioWindowEditor;
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("音效管理");
        window.Show();
    }
    private string audioName;
    private string audioPath;
    Dictionary<string, string> audioDict = new Dictionary<string, string>();

    
    void OnGUI()
    {
        //EditorGUILayout.TextField("文字1", text);
        //GUILayout.TextField("文字2");
        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名称");
        GUILayout.Label("音效路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();
        foreach(string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);
            if (GUILayout.Button("delete"))
            {
                audioDict.Remove(key);
                return;
            }
            GUILayout.EndHorizontal();
        }

        audioName = EditorGUILayout.TextField("音效名字", audioName);
        audioPath = EditorGUILayout.TextField("音效路径",audioPath);
        if(GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(audioPath);
            if (o == null)
            {
                Debug.LogWarning("音效不存在于" + audioPath + "添加不成功");
                audioPath = "";
            }
            else
            {
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("audioName has been created,please change ");
                }
                else
                {
                    audioDict.Add(audioName, audioPath);
                    SaveAudioList();
                }
            }
        }
    }
    private void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder(); 
        foreach(string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key,out value);
            sb.Append(key + "," + value + "\n");
        }
        //File.WriteAllText(AudioManager.AudioTextPath, sb.ToString());
        string savePath = Application.dataPath + "\\Framework\\Resources\\audiolist.txt";
        File.WriteAllText(savePath, sb.ToString());
    }

    
}
