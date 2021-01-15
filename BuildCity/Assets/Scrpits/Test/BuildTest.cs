using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class BuildTest : BaseMonoBehaviour
{
    public BuildForBuilding modelBuilding;

    public string modelName;

    private void OnGUI()
    {
        GUILayout.Label("模型名称");
        modelName = GUILayout.TextField(modelName);
        if (GUILayout.Button("查看"))
        {
            CreateAllBuild(modelName);
        }
    }



    public void CreateAllBuild(string modelName)
    {
        BuildHandler.Instance.manager.LoadBuildBaseRes(BuildTypeEnum.Building, modelName);

        List<BuildRuleEnum> ruleList = EnumUtil.GetEnumValue<BuildRuleEnum>();

        for (int i = 0; i < ruleList.Count; i++)
        {
            BuildRuleEnum itemRule = ruleList[i];
            GameObject objModel = BuildHandler.Instance.manager.GetBuildBaseModel(BuildTypeEnum.Building, modelName, itemRule);
            GameObject objBuild= Instantiate(gameObject, modelBuilding.gameObject);
            BuildBase buildBase= objBuild.GetComponent<BuildBase>();

            BuildBaseBean buildBaseData = new BuildBaseBean();
            Vector3 centerPostion= new Vector3(i * 5, 0, 0);
            buildBaseData.SetBuildPosition(centerPostion);
            buildBaseData.SetBuildRule(itemRule);
            buildBaseData.SetBuildType(BuildTypeEnum.Building);

            buildBase.SetBuilBaseData(buildBaseData);
            objBuild.transform.position = centerPostion;

            BuildHandler.Instance.manager.AddBuildBase(buildBase);
            buildBase.AutoCheckBuildRule();
            BuildRuleEnumTool.GetBuildRuleData(itemRule, out int number, out bool up, out bool down, out bool left, out bool right, out bool before, out bool after);
            if (up)
                CreateBuildItem(centerPostion + new Vector3(0, 1, 0));
            if (down)
                CreateBuildItem(centerPostion + new Vector3(0, -1, 0));
            if (left)
                CreateBuildItem(centerPostion + new Vector3(-1, 0, 0));
            if (right)
                CreateBuildItem(centerPostion + new Vector3(1, 0, 0));
            if (before)
                CreateBuildItem(centerPostion + new Vector3(0, 0, -1));
            if (after)
                CreateBuildItem(centerPostion + new Vector3(0, 0, 1));
            buildBase.AutoCheckBuildRule();
        }
    }

    protected void CreateBuildItem(Vector3 position)
    {
        GameObject objBuild = Instantiate(gameObject, modelBuilding.gameObject);

        BuildBase buildBase = objBuild.GetComponent<BuildBase>();

        BuildBaseBean buildBaseData = new BuildBaseBean();
        buildBaseData.SetBuildPosition(position);
        buildBaseData.SetBuildRule(BuildRuleEnum.Zero);
        buildBaseData.SetBuildType(BuildTypeEnum.Building);

        buildBase.SetBuilBaseData(buildBaseData);
        objBuild.transform.position = position;

        buildBase.AutoCheckBuildRule();

        Renderer[] rendererArrary = buildBase.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in rendererArrary)
        {
            renderer.material.color = Color.black;
        }
        BuildHandler.Instance.manager.AddBuildBase(buildBase);
    }
}