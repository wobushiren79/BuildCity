using UnityEditor;
using UnityEngine;
using System;

[Serializable]
public class BuildBaseBean
{
    //建筑类型
    public int buildType = 0;
    //建筑规则
    public int buildRule = 0;
    //建筑位置
    public Vector3Bean buildPosition;

    public BuildRuleEnum GetBuildRule()
    {
        return (BuildRuleEnum)buildRule;
    }

    public void SetBuildRule(BuildRuleEnum buildRule)
    {
        this.buildRule = (int)buildRule;
    }

    public BuildTypeEnum GetBuildType()
    {
        return (BuildTypeEnum)buildType;
    }

    public void SetBuildType(BuildTypeEnum buildType)
    {
        this.buildType = (int)buildType;
    }

    public void SetBuildPosition(Vector3 vector3)
    {
        buildPosition = new Vector3Bean(vector3);
    }
}