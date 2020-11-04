using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreService : IScoreService
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    public void OnReceiveScore()
    {
        int score = 0;
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore, score);
    }

    public void RequestScore(string url)
    {
        Debug.Log("Request score from URL ：" + url);
        OnReceiveScore();
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update Score to URL : " + url + "new score" + score);
    }

    
}
