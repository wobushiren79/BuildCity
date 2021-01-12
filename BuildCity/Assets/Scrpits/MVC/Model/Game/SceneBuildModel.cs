/*
* FileName: SceneBuild 
* Author: AppleCoffee 
* CreateTime: 2021-01-12-15:35:47 
*/

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SceneBuildModel : BaseMVCModel
{
    protected SceneBuildService serviceSceneBuild;

    public override void InitData()
    {
        serviceSceneBuild = new SceneBuildService();
    }


    /// <summary>
    /// 获取游戏数据
    /// </summary>
    /// <returns></returns>
    public SceneBuildBean GetSceneBuildData(string buildId)
    {
        SceneBuildBean data = serviceSceneBuild.QueryData(buildId);
        return data;
    }


    /// <summary>
    /// 保存游戏数据
    /// </summary>
    /// <param name="data"></param>
    public void SetSceneBuildData(SceneBuildBean data)
    {
        serviceSceneBuild.UpdateData(data);
    }

}