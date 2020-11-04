using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    private Text scoreText;
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
        scoreText.text = "0";
    }

    private void Update()
    {
        //transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0) * 0.05f);
    }
    private void OnMouseDown()
    {
        transform.position = new Vector3(Random.Range(-4, 5), Random.Range(-4, 5), 0);
        Debug.Log("OnMouseDown");
        dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
