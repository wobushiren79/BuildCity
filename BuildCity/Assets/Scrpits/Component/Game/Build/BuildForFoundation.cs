using UnityEditor;
using UnityEngine;

public class BuildForFoundation : BuildBase
{
    //public Renderer rendererForFoundation;
    public GameObject objWhite;
    public GameObject objBlack;

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
    public void ChangeColor(int type)
    {
        if (type == 1)
        {
            objWhite.SetActive(false);
            objBlack.SetActive(true);
        }
        else
        {
            objWhite.SetActive(true);
            objBlack.SetActive(false);
        }
    }

    public void SetFoundationColor(Color color)
    {
        //rendererForFoundation.material.color = color;
    }



}