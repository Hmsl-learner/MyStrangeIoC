using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MVCSContext 
/// </summary>
public class Demo1Context : MVCSContext
{
    public Demo1Context(MonoBehaviour contextView):base(contextView) { }
    protected override void mapBindings()   // 绑定映射
    {
        base.mapBindings();

        #region Model
        // 注入绑定ScoreModel                               *将ScoreModel设置为单例
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        #endregion

        #region Service
        // 注入绑定Service                                          *将ScoreService设置为单例
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();
        #endregion

        #region Command
        // 绑定请求分数命令
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        // 绑定更新分数命令
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();
        #endregion

        #region Mediator
        // 绑定View和Mediator
        mediationBinder.Bind<CubeView>().To<CubeViewMediator>();
        #endregion

        // 绑定StartCommand命令,                                  *只执行一次
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();   // 自动执行startcommand
    }
}
