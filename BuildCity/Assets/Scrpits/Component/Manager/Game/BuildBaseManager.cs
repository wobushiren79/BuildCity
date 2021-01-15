
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildBaseManager : BaseManager
{
    protected BuildRuleDictionary dicBuildRule = new BuildRuleDictionary();

    public List<BuildBaseModelBean> listBuildRuleModel = new List<BuildBaseModelBean>();

    public void InitData()
    {
        for (int i = 0; i < listBuildRuleModel.Count; i++)
        {
            BuildBaseModelBean itemData = listBuildRuleModel[i];
            dicBuildRule.Add(itemData.buildRule, itemData);
        }
    }

    /// <summary>
    /// 获取建筑模型
    /// </summary>
    /// <param name="buildRule"></param>
    /// <returns></returns>
    public GameObject GetBuildBaseModel(BuildRuleEnum buildRule)
    {
        if (dicBuildRule.TryGetValue(buildRule, out BuildBaseModelBean modelData))
        {
            if (modelData != null)
            {
                if (!CheckUtil.ListIsNull(modelData.listObjModel))
                {
                    return RandomUtil.GetRandomDataByList(modelData.listObjModel);
                }
            }
        }
        if (dicBuildRule.TryGetValue(BuildRuleEnum.Zero, out BuildBaseModelBean modelDataZero))
        {
            if (!CheckUtil.ListIsNull(modelDataZero.listObjModel))
            {
                return modelDataZero.listObjModel[0];
            }
        }
        return null;
    }

    /// <summary>
    /// 添加所有规则
    /// </summary>
    public void AddAllRule()
    {
        List<BuildRuleEnum> listData = EnumUtil.GetEnumValue<BuildRuleEnum>();
        for (int i = 0; i < listData.Count; i++)
        {
            BuildRuleEnum itemRule = listData[i];
            BuildBaseModelBean buildBaseModel = new BuildBaseModelBean();
            buildBaseModel.buildRule = itemRule;
            listBuildRuleModel.Add(buildBaseModel);
        }
    }

    /// <summary>
    /// 清除数据
    /// </summary>
    public void CleanData()
    {
        listBuildRuleModel.Clear();
    }
}