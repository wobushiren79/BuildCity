using DG.Tweening;

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildBase : BaseMonoBehaviour
{
    public BuildBaseBean buildBaseData;
    //实际建筑模型
    public GameObject objBuildModel;

    private void OnDestroy()
    {
        transform.DOKill();
    }

    /// <summary>
    /// 设置数据
    /// </summary>
    /// <param name="buildBaseData"></param>
    public virtual void SetBuilBaseData(BuildBaseBean buildBaseData)
    {
        this.buildBaseData = buildBaseData;
        AutoCheckBuildRule();
    }

    /// <summary>
    /// 设置建筑模型
    /// </summary>
    /// <param name="buildRule"></param>
    public virtual void SetBuildModel(BuildRuleEnum buildRule)
    {
        GameObject objModel = BuildHandler.Instance.manager.GetBuildBaseModel(this, buildRule, "def");
        if (objModel == null)
            return;
        if (objBuildModel)
        {
            DestroyImmediate(objBuildModel);
            objBuildModel = null;
        }
        objBuildModel = Instantiate(gameObject, objModel);

        //Renderer[] listRenderer = objBuildModel.GetComponentsInChildren<Renderer>();
        //if (listRenderer != null)
        //{
        //    foreach (Renderer itemRenderer in  listRenderer)
        //    {
        //        Shader shader= Shader.Find("Color/MasterShaderLocalSpace");
        //        itemRenderer.material.shader = shader;
        //    }
        //}

        objBuildModel.transform.localPosition = Vector3.zero;
        objBuildModel.transform.eulerAngles = Vector3.zero;
        objBuildModel.transform.localScale = Vector3.one;
    }

    /// <summary>
    /// 自动检测建筑的朝向规则
    /// </summary>
    public virtual void AutoCheckBuildRule()
    {
        List<BuildBase> listData = BuildHandler.Instance.manager.GetAroundBuildBase(this);
        BuildRuleEnum buildRule = GetBuildRule(listData);
        ChangeBuildRule(buildRule);
    }

    /// <summary>
    /// 修改建造规则
    /// </summary>
    public virtual void ChangeBuildRule(BuildRuleEnum buildRule)
    {
        //方向不同时才修改模型
        if (buildRule == buildBaseData.GetBuildRule())
            return;
        buildBaseData.SetBuildRule(buildRule);
        SetBuildModel(buildRule);
        AnimForChangeRule();
    }

    /// <summary>
    /// 获取建筑规则
    /// </summary>
    /// <param name="listData"></param>
    public virtual BuildRuleEnum GetBuildRule(List<BuildBase> listData)
    {
        bool upRule = false;
        bool downRule = false;
        bool leftRule = false;
        bool rightRule = false;
        bool beforeRule = false;
        bool afterRule = false;
        for (int i = 0; i < listData.Count; i++)
        {
            BuildBase buildBase = listData[i];
            Vector3 tempRule = (buildBaseData.buildPosition.GetVector3() - buildBase.buildBaseData.buildPosition.GetVector3());
            if (tempRule.y == 1)
                downRule = true;
            if (tempRule.y == -1)
                upRule = true;
            if (tempRule.x == 1)
                leftRule = true;
            if (tempRule.x == -1)
                rightRule = true;
            if (tempRule.z == 1)
                beforeRule = true;
            if (tempRule.z == -1)
                afterRule = true;
        }
        return BuildRuleEnumTool.GetBuildRule(listData.Count, upRule, downRule, leftRule, rightRule, beforeRule, afterRule);
    }
    /// <summary>
    /// 动画  建造
    /// </summary>
    public virtual void AnimForBuild()
    {
        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOScale(Vector3.zero, 0.2f).From().SetEase(Ease.OutBack);
    }

    /// <summary>
    /// 动画 改变规则
    /// </summary>
    public virtual void AnimForChangeRule()
    {
        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 5, 0.5f);
    }
}