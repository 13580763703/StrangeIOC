using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class GameObjectPool
{
    [SerializeField]
    public string name;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int maxAmount;

    [NonSerialized]
    private List<GameObject> goList = new List<GameObject>();

    /// <summary>
    /// 表示从资源中获取一个实例
    /// </summary>
    /// <returns></returns>
    public GameObject GetInst()
    {
        foreach(GameObject go in goList)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
                return go;
            }
        }
        if(goList.Count > maxAmount)
        {
            GameObject.Destroy(goList[0]);
            goList.RemoveAt(0);
        }
        GameObject temp = GameObject.Instantiate(prefab) as GameObject;
        goList.Add(temp);
        return temp;
    }
}
