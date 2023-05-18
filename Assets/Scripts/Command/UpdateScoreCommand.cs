using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreCommand : EventCommand
{
    [Inject]
    public ScoreModel scoreModel { get; set; }
    [Inject]
    public IScoreService scoreService { get; set; }

    public override void Execute()
    {
        scoreModel.score++;
        scoreService.UpdateScore("hettp://xxx/x", scoreModel.score);
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, scoreModel.score);
    }
}
