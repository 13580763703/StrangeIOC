using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PoolManager
{
    [MenuItem("Manager/Create GameObjectPoolConfig")]
    static void CreateGameObjectPoolList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();
        string path ="Assets/Framework/Resources/gameobjectpool.asset";
        AssetDatabase.CreateAsset(poolList,path);
        AssetDatabase.SaveAssets();
    }
}
