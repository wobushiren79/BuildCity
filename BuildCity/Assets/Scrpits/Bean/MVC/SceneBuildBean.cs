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
    /// ���ӽ�������
    /// </summary>
    /// <param name="buildData"></param>
    public void AddListBuildData(BuildBaseBean buildData)
    {
        listBuildData.Add(buildData);
    }

    /// <summary>
    /// �Ƴ�����
    /// </summary>
    /// <param name="buildData"></param>
    public void RemoveListBuildData(BuildBaseBean buildData)
    {
        if (listBuildData.Contains(buildData))
            listBuildData.Remove(buildData);
    }

    /// <summary>
    /// ������������
    /// </summary>
    public void ClearListBuildData()
    {
        listBuildData.Clear();
    }

    /// <summary>
    /// ���õ��Ƿ��н���
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