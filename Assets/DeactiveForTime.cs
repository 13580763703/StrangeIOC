using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveForTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Deactive", 5);
    }

    void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
