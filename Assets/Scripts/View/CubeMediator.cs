using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMediator : Mediator
{
    [Inject]
    public CubeView cubeview { get; set; }
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }
    public override void OnRegister()
    {
        cubeview.Init();
        Debug.Log(cubeview);
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        Debug.Log("ihaverunning");

        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);//发起请求分数的命令
        Debug.Log("request score");
        
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange,OnScoreChange);
    }
    
    public void OnScoreChange(IEvent evt)
    {
        cubeview.UpdateScore((int)evt.data);
    }
}
