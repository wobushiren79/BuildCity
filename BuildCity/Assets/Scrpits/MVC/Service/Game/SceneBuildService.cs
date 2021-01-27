/*
* FileName: SceneBuild 
* Author: AppleCoffee 
* CreateTime: 2021-01-12-15:35:47 
*/

using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

public class SceneBuildService : BaseDataStorage<SceneBuildBean>
{
    protected readonly string saveFileName;

    public SceneBuildService()
    {
        saveFileName = "SceneBuild_";
    }


    /// <summary>
    /// 查询游戏配置数据
    /// </summary>
    /// <returns></returns>
    public SceneBuildBean QueryData(string buildId)
    {
        return BaseLoadData(saveFileName + buildId);
    }


    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="data"></param>
    public void UpdateData(SceneBuildBean data)
    {
        BaseSaveData(saveFileName + data.buildId, data);
    }
}