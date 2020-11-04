using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreService 
{
    IEventDispatcher dispatcher { get; set; }

    void RequestScore(string url);  // 请求分数
    void OnReceiveScore();       // 获得分数
    void UpdateScore(string url, int score);    // 更新分数

}
