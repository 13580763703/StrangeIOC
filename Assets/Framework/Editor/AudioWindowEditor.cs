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
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();
    //private string savePath;

    //private void OnEnable()
    //{
    //    savePath = Application.dataPath + "/Framework/Resources/audiolist.txt";
    //}
    void Awake()
    {
        //OnEnable();
        LoadAudioList();
    }

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
                SaveAudioList();
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

    //private string savePath = Application.dataPath + "\\Framework\\Resources\\audiolist.txt";

    private void OnInspectorUpdate()
    {
        Debug.Log("Update");
        LoadAudioList();
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
        Debug.Log(AudioManager.AudioTextPath);
        File.WriteAllText(AudioManager.AudioTextPath, sb.ToString());
    }
    private void LoadAudioList()
    {
        Debug.Log(AudioManager.AudioTextPath);
        audioDict = new Dictionary<string, string>();
        if(File.Exists(AudioManager.AudioTextPath) == false) return;
        string[] lines = File.ReadAllLines(AudioManager.AudioTextPath);
        foreach(string line in lines)
        {
            if(string.IsNullOrEmpty(line)) continue;
            string[] keyValue = line.Split(','); 
            audioDict.Add(keyValue[0], keyValue[1]);    
        }
    }
    
}
