using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PoolManagerEditor
{
    [MenuItem("Manager/Create GameObjectPoolConfig")]
    static void CreateGameObjectPoolList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();
        string path = PoolManager.PoolConfigPath;
        AssetDatabase.CreateAsset(poolList,path);
        AssetDatabase.SaveAssets();
    }
}
