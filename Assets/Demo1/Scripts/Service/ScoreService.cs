using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScoreService : IScoreService
{
    [Inject]
    public IEventDispatcher dispatcher { get;set; }

    public void RequestScore(string url)
    {
        //Debug.Log("this is ScoreRequest from url"+ url);
        OnServiceScore();
    }

    public void OnServiceScore()
    {
        int score = Random.Range(0, 100);
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore,score);
        //Debug.Log("On Service Score");
    }

    public void UpdateScore(string url,int score)
    {
        Debug.Log("UpdateScore to url"+url + "new score"+score);
    }
}
