using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreService
{
    void ScoreRequest(string url);//请求分数
    void OnServiceScore();//收到服务器发过来的分数

    void UpdateScore(string url,int score);
   
}
