using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 请求分数的命令
/// </summary>
public class RequestScoreCommand : EventCommand // EventCommand中包含一个全局Dispatcher属性
{
    [Inject]
    public IScoreService scoreService { get; set; }
    [Inject]
    public ScoreModel scoreModel { get; set; }
    public override void Execute()
    {
        Retain();   // 保持命令不被销毁
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreService.RequestScore("http://xx/xxx/xxx");
    }

    void OnComplete(IEvent evt)  // IEvent 存储参数
    {
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, evt.data);
        scoreModel.Score = (int)evt.data;
        Release();  // 命令执行完毕后销毁
    }
    
}
