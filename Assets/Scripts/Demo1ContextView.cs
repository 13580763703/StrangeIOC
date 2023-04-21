using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1ContextView : ContextView
{
    void Awake()
    {
        this.context = new Demo1Context(this);//Æô¶¯strangeIoc¿ò¼Ü

        //context.start();
    }
}
