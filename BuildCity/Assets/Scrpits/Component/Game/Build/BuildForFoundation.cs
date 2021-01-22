using UnityEditor;
using UnityEngine;

public class BuildForFoundation : BuildBase
{
    public Renderer rendererForFoundation;

    /// <summary>
    /// 设置数据
    /// </summary>
    /// <param name="buildBaseData"></param>
    public override void SetBuilBaseData(BuildBaseBean buildBaseData)
    {
        this.buildBaseData = buildBaseData;
    }
    public override void AutoCheckBuildRule()
    {

    }

    public void SetFoundationColor(Color color)
    {
        rendererForFoundation.material.color = color;
    }


   
}