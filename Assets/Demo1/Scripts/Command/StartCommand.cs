using strange.extensions.command.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command
{
    [Inject]
    public AudioManager audioManager { get; set; }
    /// <summary>
    /// 当这个命令被执行的时候，默认会调用execute方法
    /// </summary>
    public override void Execute()
    {
        audioManager.Init();
        PoolManager.Instance.Init();
    }
}
