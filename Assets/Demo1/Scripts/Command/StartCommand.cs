using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller 初始化命令
/// </summary>
public class StartCommand : Command
{
    /// <summary>
    /// 当命令被执行时调用
    /// 不调用父类中的方法
    /// </summary>
    public override void Execute()
    {
        Debug.Log("startcommand execute");
    }
}
