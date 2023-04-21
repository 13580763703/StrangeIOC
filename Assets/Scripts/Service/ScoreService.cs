using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScoreService : IScoreService
{
    public void ScoreRequest(string url)
    {
        Debug.Log("this is ScoreRequest from url"+ url);
        OnServiceScore();
    }

    public void OnServiceScore()
    {
        int score = Random.Range(0, 100);
        Console.WriteLine("On Service Score");
    }

    public void UpdateScore(string url,int score)
    {
        Debug.Log("UpdateScore to url"+url + "new score"+score);
    }
}
