using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreCommand : EventCommand
{
    [Inject]
    public ScoreModel scoreModel { get; set; }
    [Inject]
    public IScoreService scoreService { get; set; }
    public override void Execute()
    {
        scoreModel.Score++; // 分数+1
        scoreService.UpdateScore("http://xx/xxx/xxx/xxx", scoreModel.Score);    // 更新服务器端数据
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, scoreModel.Score);  // 通知mediator更改view的显示
    }
}
