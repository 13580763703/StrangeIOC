using strange.examples.multiplecontexts.game;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScoreCommand : EventCommand
{
    [Inject]
    public IScoreService scoreService { get; set; }
    [Inject]
    public ScoreModel scoreModel { get; set; }
    public override void Execute()
    {
        Retain();//±£´æ
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreService.RequestScore("http://adwda/asdawda/dwad"); 
    }

    private void OnComplete(IEvent evt)
    {
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreModel.score = (int)evt.data;
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, evt.data);
        Debug.Log("OnComplete:" + evt.data);

        Release();//Ïú»Ù
    }
}
