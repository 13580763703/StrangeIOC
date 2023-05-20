using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
/// <summary>
/// ��Ч�������
/// </summary>
public class AudioWindowEditor : EditorWindow
{
    [MenuItem("Manager/AudioManager")]
    static void CreateWindow() {
        //Rect rect = new Rect(400,400,400,400);
        //AudioWindowEditor window = EditorWindow.GetWindowWithRect(typeof(AudioWindowEditor),rect) as AudioWindowEditor;
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("��Ч����");
        window.Show();
    }
    private string audioName;
    private string audioPath;
    Dictionary<string, string> audioDict = new Dictionary<string, string>();

    
    void OnGUI()
    {
        //EditorGUILayout.TextField("����1", text);
        //GUILayout.TextField("����2");
        GUILayout.BeginHorizontal();
        GUILayout.Label("��Ч����");
        GUILayout.Label("��Ч·��");
        GUILayout.Label("����");
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

        audioName = EditorGUILayout.TextField("��Ч����", audioName);
        audioPath = EditorGUILayout.TextField("��Ч·��",audioPath);
        if(GUILayout.Button("�����Ч"))
        {
            object o = Resources.Load(audioPath);
            if (o == null)
            {
                Debug.LogWarning("��Ч��������" + audioPath + "��Ӳ��ɹ�");
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
