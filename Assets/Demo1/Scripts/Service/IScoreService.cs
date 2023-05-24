using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreService
{
    void RequestScore(string url);//�������
    void OnServiceScore();//�յ��������������ķ���

    void UpdateScore(string url,int score);
   
    IEventDispatcher dispatcher { get; set; }
}
