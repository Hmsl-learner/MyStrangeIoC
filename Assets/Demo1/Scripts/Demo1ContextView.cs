using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;

/// <summary>
/// Root 
/// </summary>
public class Demo1ContextView : ContextView
{
    private void Awake()
    {
        this.context = new Demo1Context(this);  // 自动启动StrangeIoC框架
    }
}
