using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreService
{
    void ScoreRequest(string url);//�������
    void OnServiceScore();//�յ��������������ķ���

    void UpdateScore(string url,int score);
   
}
