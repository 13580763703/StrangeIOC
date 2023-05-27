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

    public GameObject GetInst()
    {
        return null;
    }
}
