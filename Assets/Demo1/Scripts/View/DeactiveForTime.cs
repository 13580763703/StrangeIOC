using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveForTime : MonoBehaviour
{
    // Start is called before the first frame update
    

    void OnEnable()
    {
        Invoke("Deactive", 3);
    }
    void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
