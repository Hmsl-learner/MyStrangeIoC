using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeViewMediator : Mediator
{
    [Inject]    // 注入 当StrangeIoC给View绑定了Mediator后赋值
    public CubeView cubeView { get; set; }
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]    // 将dispatcher设置为全局派发器
    public IEventDispatcher dispatcher { get; set; } // 派发器 用于模块间的交互
    /// <summary>
    /// 绑定后调用
    /// </summary>
    public override void OnRegister()
    {
        Debug.Log("OnRegister");
        cubeView.Init();
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown, OnClickDown);
        // 通过dispatcher 发送请求分数的命令
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }
    /// <summary>
    /// 解除绑定后调用
    /// </summary>
    public override void OnRemove()
    {
        Debug.Log("OnRemove");
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnClickDown);
    }
    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);
    }
    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }

}
