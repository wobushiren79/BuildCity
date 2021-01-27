/*
* FileName: SceneBuild 
* Author: AppleCoffee 
* CreateTime: 2021-01-12-15:35:47 
*/

using UnityEngine;
using UnityEditor;
using System;

using System.Collections.Generic;

[Serializable]
public class SceneBuildBean : BaseBean
{
    public string buildId;

    public int sceneSizeX;
    public int sceneSizeY;
    public int sceneSizeZ;

    public List<BuildBaseBean> listBuildData = new List<BuildBaseBean>();

    public SceneBuildBean(int sceneSizeX, int sceneSizeY, int sceneSizeZ)
    {
        buildId = SystemUtil.GetUUID(SystemUtil.UUIDTypeEnum.N);
        this.sceneSizeX = sceneSizeX;
        this.sceneSizeY = sceneSizeY;
        this.sceneSizeZ = sceneSizeZ;
    }

    /// <summary>
    /// 增加建造数据
    /// </summary>
    /// <param name="buildData"></param>
    public void AddListBuildData(BuildBaseBean buildData)
    {
        listBuildData.Add(buildData);
    }

    /// <summary>
    /// 移除数据
    /// </summary>
    /// <param name="buildData"></param>
    public void RemoveListBuildData(BuildBaseBean buildData)
    {
        if (listBuildData.Contains(buildData))
            listBuildData.Remove(buildData);
    }

    /// <summary>
    /// 清理建筑数据
    /// </summary>
    public void ClearListBuildData()
    {
        listBuildData.Clear();
    }

    /// <summary>
    /// 检测该点是否有建筑
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool CheckHasBuild(Vector3 position)
    {
        for (int i = 0; i < listBuildData.Count; i++)
        {
            BuildBaseBean buildData = listBuildData[i];
            if (position == buildData.buildPosition.GetVector3())
            {
                return true;
            }
        }
        return false;
    }
}