using strange.extensions.context.api;
using strange.extensions.context.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1Context : MVCSContext
{
   public Demo1Context(MonoBehaviour view) : base(view) { }

    protected override void mapBindings()
    {
        //model

        //service

        //command

        //mediator

        // 绑定开始事件创建一个startcommand
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
