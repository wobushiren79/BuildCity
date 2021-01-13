
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildBaseManager : BaseManager
{
    public BuildRuleDictionary dicBuildRule = new BuildRuleDictionary();

    /// <summary>
    /// 获取建筑模型
    /// </summary>
    /// <param name="buildRule"></param>
    /// <returns></returns>
    public GameObject GetBuildBaseModel(BuildRuleEnum buildRule)
    {
        if (dicBuildRule.TryGetValue(buildRule, out GameObject obj))
        {
            if (obj == null)
                if (dicBuildRule.TryGetValue(BuildRuleEnum.Zero, out GameObject objZero))
                {
                    return objZero;
                }
            return obj;
        }
        else
        {
            if (dicBuildRule.TryGetValue(BuildRuleEnum.Zero, out GameObject objZero))
            {
                return objZero;
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
            dicBuildRule.Add(itemRule, null);
        }
    }

    /// <summary>
    /// 清除数据
    /// </summary>
    public void CleanData()
    {
        dicBuildRule.Clear();
        dicBuildRule = new BuildRuleDictionary();
    }
}