using JetBrains.Annotations;
using strange.extensions.dispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    private TextMeshPro scoreText;
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    [Inject]
    public AudioManager audioManager { get; set; }
    /// <summary>
    /// ≥ı ºªØ
    /// </summary>
    public void Init()
    {
        scoreText = GetComponentInChildren<TextMeshPro>();
        Debug.Log(audioManager);    
    }

    public void Update()
    {
        transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2))*.1f);
    }

    private void OnMouseDown()
    {
        dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);
        audioManager.Play("Hit");
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
