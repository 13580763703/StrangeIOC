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
    /// ��������ִ�е�ʱ��Ĭ�ϻ����execute����
    /// </summary>
    public override void Execute()
    {
        audioManager.Init();
        PoolManager.Instance.Init();
    }
}
