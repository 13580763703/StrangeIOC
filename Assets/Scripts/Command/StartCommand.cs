using strange.extensions.command.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command
{
    /// <summary>
    /// 当这个命令被执行的时候，默认会调用execute方法
    /// </summary>
    public override void Execute()
    {
        Debug.Log("start command execute");
        Console.WriteLine("aa");
    }
}
