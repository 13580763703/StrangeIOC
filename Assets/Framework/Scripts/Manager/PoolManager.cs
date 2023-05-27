using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager 
{
    private static PoolManager _instance;
    public static PoolManager Instance 
    { 
        get 
        {   
            if (_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance; 
        } 
    }

    private static readonly string poolConfigPathPrefix = Application.dataPath + "\\Framework\\Resources\\";
    private static readonly string poolConfigPathMiddle = "gameobjectpool";
    private static readonly string poolConfigPathPostfix = ".asset";

    public static string PoolConfigPath
    {
        get { return poolConfigPathPrefix + poolConfigPathMiddle + poolConfigPathPostfix; }
    }

    private Dictionary<string, GameObjectPool> poolDict;
    private PoolManager()
    {
        GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(poolConfigPathMiddle);
        poolDict = new Dictionary<string, GameObjectPool>();
        foreach(GameObjectPool pool in poolList.poolList)
        {
            poolDict.Add(pool.name,pool);
        }

    }
    public void Init()
    {
        //do nothing
    }

    public GameObject GetInst(string poolName)
    {
        GameObjectPool pool;
        if(poolDict.TryGetValue(poolName,out pool)){
            return pool.GetInst();
        }
        Debug.LogWarning("pool" + poolName + "is not exist");
        return null;
    }
}
