using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class UIViewForBuildMode : BaseMonoBehaviour
{
    public Image ui_IvBuild;
    public Image ui_IvBuildBG;
    public Image ui_IvDemolition;
    public Image ui_IvDemolitionBG;

    public Button ui_BtModeBuild;
    public Button ui_BtModeDemolition;

    public Sprite spBuildSelect;
    public Sprite spBuildUnSelect;

    public Sprite spDemolitionSelect;
    public Sprite spDemolitionUnSelect;

    private void Awake()
    {
        AutoLinkUI();
        if (ui_BtModeBuild)
            ui_BtModeBuild.onClick.AddListener(OnClickForChangeBuild);
        if (ui_BtModeDemolition)
            ui_BtModeDemolition.onClick.AddListener(OnClickForChangeDemolition);
        ChangeBuildMode(BuildControlModeEnum.Build);
    }

    public void OnClickForChangeBuild()
    {
        ChangeBuildMode(BuildControlModeEnum.Build);
    }

    public void OnClickForChangeDemolition()
    {
        ChangeBuildMode(BuildControlModeEnum.Demolition);
    }

    /// <summary>
    /// 修改建筑模式
    /// </summary>
    /// <param name="buildMode"></param>
    public void ChangeBuildMode(BuildControlModeEnum buildMode)
    {
        BuildHandler.Instance.controlForBuild.ChangeMode(buildMode);
        switch (buildMode)
        {
            case BuildControlModeEnum.Build:
                ui_IvBuild.sprite = spBuildSelect;
                ui_IvDemolition.sprite = spDemolitionUnSelect;
                ui_IvBuildBG.gameObject.SetActive(true);
                ui_IvDemolitionBG.gameObject.SetActive(false);
                break;
            case BuildControlModeEnum.Demolition:
                ui_IvBuild.sprite = spBuildUnSelect;
                ui_IvDemolition.sprite = spDemolitionSelect;
                ui_IvBuildBG.gameObject.SetActive(false);
                ui_IvDemolitionBG.gameObject.SetActive(true);
                break;
        }
    }

}