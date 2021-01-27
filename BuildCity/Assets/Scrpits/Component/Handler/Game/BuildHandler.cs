using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuildHandler : BaseHandler<BuildHandler, BuildManager>
{
    public BuildForBuilding modelForBuilding;
    public BuildForFoundation modelForFoundation;

    public BuildControl controlForBuild;

    protected override void Awake()
    {
        base.Awake();
        controlForBuild = CptUtil.AddCpt<BuildControl>(gameObject);
        controlForBuild.ChangeMode(BuildControlModeEnum.Build);
    }

    public void InitBuild(SceneBuildBean sceneBuild)
    {
        manager.ClearData();
        CreateFoundation(sceneBuild);
    }

    /// <summary>
    /// 创建地基
    /// </summary>
    /// <param name="sceneBuild"></param>
    public void CreateFoundation(SceneBuildBean sceneBuild)
    {
        for (int x = 0; x < sceneBuild.sceneSizeX; x++)
        {
            for (int z = 0; z < sceneBuild.sceneSizeZ; z++)
            {
                BuildForFoundation buildFoundation = CreateBuildBase<BuildForFoundation>(BuildTypeEnum.Foundation, new Vector3(x, -1, z));
                if (x % 2 == 0)
                {
                    if (z % 2 == 0)
                    {
                        buildFoundation.ChangeColor(1);
                    }
                    else
                    {
                        buildFoundation.ChangeColor(2);
                    }
                }
                else
                {
                    if (z % 2 == 0)
                    {
                        buildFoundation.ChangeColor(2);
                    }
                    else
                    {
                        buildFoundation.ChangeColor(1);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 创建一个建筑
    /// </summary>
    /// <param name="buildPosition"></param>
    public T CreateBuildBase<T>(BuildTypeEnum buildType, Vector3 buildPosition) where T : BuildBase
    {
        BuildBase modelBuild = null;
        //设置建造数据
        BuildBaseBean buildBaseData = new BuildBaseBean();
        buildBaseData.SetBuildType(buildType);
        buildBaseData.SetBuildRule(BuildRuleEnum.Zero);
        buildBaseData.SetBuildPosition(buildPosition);
        //生成不同的模型
        switch (buildType)
        {
            case BuildTypeEnum.Building:
                modelBuild = modelForBuilding;
                break;
            case BuildTypeEnum.Foundation:
                modelBuild = modelForFoundation;
                break;
        }
        if (modelBuild == null)
            return null;
        GameObject objBuild = Instantiate(gameObject, modelBuild.gameObject, buildPosition);
        T cptBuild = objBuild.GetComponent<T>();
        cptBuild.SetBuilBaseData(buildBaseData);

        //增加数据
        GameDataHandler.Instance.manager.AddSceneListBuildData(buildBaseData);
        manager.AddBuildBase(cptBuild);
        //建筑动画
        AnimForBuild(buildType, cptBuild);

        //获取周围方块
        List<BuildBase> listAroundBuild = manager.GetAroundBuildBase(cptBuild);
        //改变周围方块状态
        for (int i = 0; i < listAroundBuild.Count; i++)
        {
            BuildBase itemBase = listAroundBuild[i];
            itemBase.AutoCheckBuildRule();
        }

        return cptBuild;
    }

    /// <summary>
    /// 拆除建筑
    /// </summary>
    /// <param name="buildBase"></param>
    public void DestroyBuildBase(BuildBase buildBase)
    {
        //获取周围方块
        List<BuildBase> listAroundBuild = manager.GetAroundBuildBase(buildBase);

        //移除数据
        GameDataHandler.Instance.manager.RemoveSceneListBuildData(buildBase.buildBaseData);
        manager.RemoveBuildBaes(buildBase);
        DestroyImmediate(buildBase.gameObject);

        //改变周围方块状态
        for (int i = 0; i < listAroundBuild.Count; i++)
        {
            BuildBase itemBase = listAroundBuild[i];
            itemBase.AutoCheckBuildRule();
        }

    }

    /// <summary>
    /// 建造动画
    /// </summary>
    /// <param name="buildType"></pa ram>
    /// <param name="build"></param>
    public void AnimForBuild(BuildTypeEnum buildType, BuildBase buildBase)
    {
        switch (buildType)
        {
            case BuildTypeEnum.Building:
                buildBase.AnimForBuild();
                break;
            case BuildTypeEnum.Foundation:
                break;
        }
    }

}
