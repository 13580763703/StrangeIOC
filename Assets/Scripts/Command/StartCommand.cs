using strange.extensions.command.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command
{
    /// <summary>
    /// ��������ִ�е�ʱ��Ĭ�ϻ����execute����
    /// </summary>
    public override void Execute()
    {
        Debug.Log("start command execute");
        Console.WriteLine("aa");
    }
}
