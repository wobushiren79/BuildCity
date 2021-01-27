/*
* FileName: SceneBuild 
* Author: AppleCoffee 
* CreateTime: 2021-01-12-15:35:47 
*/

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneBuildController : BaseMVCController<SceneBuildModel, ISceneBuildView>
{

    public SceneBuildController(BaseMonoBehaviour content, ISceneBuildView view) : base(content, view)
    {

    }

    public override void InitData()
    {

    }

    /// <summary>
    /// 获取数据
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public SceneBuildBean GetSceneBuildData(string buildId,Action<SceneBuildBean> action)
    {
        SceneBuildBean data = GetModel().GetSceneBuildData(buildId);
        if (data == null) {
            GetView().GetSceneBuildFail("没有数据",null);
            return null;
        }
        GetView().GetSceneBuildSuccess<SceneBuildBean>(data, action);
        return data;
    }
} 