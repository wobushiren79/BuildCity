using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : BaseManager
{
    public Dictionary<Vector3, BuildBase> dicBuildBase = new Dictionary<Vector3, BuildBase>();

    //所有的模型
    public Dictionary<string, BuildBaseManager> dicBuildBaseForBuilding = new Dictionary<string, BuildBaseManager>();

    /// <summary>
    /// 获取建筑模型
    /// </summary>
    /// <param name="buildTypeEnum"></param>
    /// <param name="name"></param>
    /// <param name="buildRule"></param>
    public GameObject GetBuildBaseModel(BuildTypeEnum buildTypeEnum,string name,BuildRuleEnum buildRule)
    {
        if (dicBuildBaseForBuilding.TryGetValue(name, out BuildBaseManager buildBaseManager))
        {
           return buildBaseManager.GetBuildBaseModel(buildRule);
        }
        return null;
    }

    /// <summary>
    /// 加载资源
    /// </summary>
    /// <param name="buildType"></param>
    /// <param name="resName"></param>
    public void LoadBuildBaseRes(BuildTypeEnum buildType, string resName)
    {
        if (dicBuildBaseForBuilding.ContainsKey(resName))
        {
            return;
        }
        string path = "build/";
        switch (buildType)
        {
            case BuildTypeEnum.Building:
                path += "building/";
                break;
        }
        GameObject obj = LoadAssetUtil.SyncLoadAsset<GameObject>(path + resName, resName);
        BuildBaseManager buildBaseManager = obj.GetComponent<BuildBaseManager>();
        buildBaseManager.InitData();
        if (buildBaseManager)
            dicBuildBaseForBuilding.Add(resName, buildBaseManager);
    }

    /// <summary>
    /// 获取周围6格格子
    /// </summary>
    /// <param name="centerBuildBase"></param>
    public List<BuildBase> GetAroundBuildBase(BuildBase centerBuildBase)
    {
        List<BuildBase> listData = new List<BuildBase>();
        Vector3 centerPosition = centerBuildBase.buildBaseData.buildPosition.GetVector3();
        listData = GetBuildBaseByPosition(listData, centerPosition + new Vector3(1, 0, 0));
        listData = GetBuildBaseByPosition(listData, centerPosition + new Vector3(-1, 0, 0));
        listData = GetBuildBaseByPosition(listData, centerPosition + new Vector3(0, 1, 0));
        listData = GetBuildBaseByPosition(listData, centerPosition + new Vector3(0, -1, 0));
        listData = GetBuildBaseByPosition(listData, centerPosition + new Vector3(0, 0, 1));
        listData = GetBuildBaseByPosition(listData, centerPosition + new Vector3(0, 0, -1));
        return listData;
    }

    /// <summary>
    /// 增加建筑物
    /// </summary>
    /// <param name="buildBase"></param>
    public void AddBuildBase(BuildBase buildBase)
    {
        Vector3 buildPosition = buildBase.buildBaseData.buildPosition.GetVector3();
        if (dicBuildBase.ContainsKey(buildPosition))
        {
            dicBuildBase[buildPosition] = buildBase;
        }
        else
        {
            dicBuildBase.Add(buildPosition, buildBase);
        }
    }

    /// <summary>
    /// 移除建筑物
    /// </summary>
    /// <param name="buildBase"></param>
    public void RemoveBuildBaes(BuildBase buildBase)
    {
        Vector3 buildPosition = buildBase.buildBaseData.buildPosition.GetVector3();
        if (dicBuildBase.ContainsKey(buildPosition))
        {
            dicBuildBase.Remove(buildPosition);
        }
    }

    /// <summary>
    /// 通过坐标获取建筑
    /// </summary>
    /// <param name="listData"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public List<BuildBase> GetBuildBaseByPosition(List<BuildBase> listData, Vector3 position)
    {
        BuildBase buildBase = GetBuildBaseByPosition(position);
        if (buildBase)
        {
            listData.Add(buildBase);
        }
        return listData;
    }

    /// <summary>
    /// 通过坐标获取建筑
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public BuildBase GetBuildBaseByPosition(Vector3 position)
    {
        if (dicBuildBase.TryGetValue(position, out BuildBase buildBase))
        {
            return buildBase;
        }
        return null;
    }
}
