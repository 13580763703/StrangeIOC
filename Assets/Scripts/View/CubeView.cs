using JetBrains.Annotations;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    private TextMeshPro scoreText;
    /// <summary>
    /// ≥ı ºªØ
    /// </summary>
    public void Init()
    {
        scoreText = GetComponentInChildren<TextMeshPro>();
    }

    public void Update()
    {
        transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2))*.1f);
    }

    private void OnMouseDown()
    {
        Debug.Log("On Mouse Down");
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
