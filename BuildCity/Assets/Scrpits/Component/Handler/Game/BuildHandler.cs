using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHandler : BaseHandler<BuildHandler, BuildManager>
{
    public BuildForBuilding modelForBuilding;
    public BuildForFoundation modelForFoundation;
    public void InitBuild(SceneBuildBean sceneBuild)
    {
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
                        buildFoundation.SetFoundationColor(Color.white);
                    }
                    else
                    {
                        buildFoundation.SetFoundationColor(Color.black);
                    }
                }
                else
                {
                    if (z % 2 == 0)
                    {
                        buildFoundation.SetFoundationColor(Color.black);
                    }
                    else
                    {
                        buildFoundation.SetFoundationColor(Color.white);
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
        return cptBuild;
    }

}
