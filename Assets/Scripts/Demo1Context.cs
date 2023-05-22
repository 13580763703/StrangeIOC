using strange.examples.multiplecontexts.game;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;

public class Demo1Context : MVCSContext
{
   public Demo1Context(MonoBehaviour view) : base(view) { }

    protected override void mapBindings()
    {
        //manager
        injectionBinder.Bind<AudioManager>().To<AudioManager>().ToSingleton(); 
        //model
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        //service
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();
        //command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();
        //mediator
        mediationBinder.Bind<CubeView>().To<CubeMediator>();
        // 绑定开始事件创建一个startcommand
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
