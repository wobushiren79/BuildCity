
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameDataManager : BaseManager, ISceneBuildView
{
    protected SceneBuildController controllerForSceneBuild;

    protected SceneBuildBean sceneBuild;
    private void Awake()
    {
        controllerForSceneBuild = new SceneBuildController(this, this);
    }

    /// <summary>
    /// 创建新的场景建造
    /// </summary>
    /// <returns></returns>
    public SceneBuildBean CreateNewSceneData(int sizeX, int sizeY, int sizeZ)
    {
        sceneBuild = new SceneBuildBean(sizeX, sizeY, sizeZ);
        return sceneBuild;
    }

    /// <summary>
    /// 清理数据
    /// </summary>
    /// <returns></returns>
    public SceneBuildBean ClearSceneData()
    {
        sceneBuild.ClearListBuildData();
        return sceneBuild;
    }

    /// <summary>
    /// 获取场景数据
    /// </summary>
    /// <returns></returns>
    public SceneBuildBean GetSceneData()
    {
        return sceneBuild;
    }

    /// <summary>
    /// 获取场景建造数据
    /// </summary>
    /// <returns></returns>
    public List<BuildBaseBean> GetSceneListBuildData()
    {
        SceneBuildBean sceneBuild = GetSceneData();
        return sceneBuild.listBuildData;
    }

    /// <summary>
    /// 增加场景建造数据
    /// </summary>
    /// <param name="buildData"></param>
    public void AddSceneListBuildData(BuildBaseBean buildData)
    {
        SceneBuildBean sceneBuild = GetSceneData();
        sceneBuild.AddListBuildData(buildData);
    }

    /// <summary>
    /// 移除场景建造数据
    /// </summary>
    /// <param name="buildData"></param>
    public void RemoveSceneListBuildData(BuildBaseBean buildData)
    {
        SceneBuildBean sceneBuild = GetSceneData();
        sceneBuild.RemoveListBuildData(buildData);
    }

    #region 获取数据
    public void GetSceneBuildFail(string failMsg, Action action)
    {

    }

    public void GetSceneBuildSuccess<T>(T data, Action<T> action)
    {

    }
    #endregion
}