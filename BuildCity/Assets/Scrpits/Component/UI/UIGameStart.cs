using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class UIGameStart : BaseUIComponent, UIViewForCameraMove.ICallBack
{
    public UIViewForCameraMove ui_BtLeft;
    public UIViewForCameraMove ui_BtRight;
    public Toggle ui_CbDemolition;

    private void Start()
    {
        if (ui_BtLeft)
            ui_BtLeft.SetCallBack(this);
        if (ui_BtRight)
            ui_BtRight.SetCallBack(this);
        if (ui_CbDemolition)
            ui_CbDemolition.onValueChanged.AddListener(OnClickForDemolition);
    }

    #region 拆除模式回调
    public void OnClickForDemolition(bool value)
    {
        if (value)
            BuildHandler.Instance.controlForBuild.ChangeMode(BuildControl.BuildModeEnum.Demolition);
        else
            BuildHandler.Instance.controlForBuild.ChangeMode(BuildControl.BuildModeEnum.Build);
    }
    #endregion

    #region 镜头移动按钮回调
    public void OnClickForCameraMove(UIViewForCameraMove uiViewForCamera)
    {
        if (uiViewForCamera == ui_BtLeft)
        {
            CameraHandler.Instance.RotateCameraAround(-1);
        }
        else if (uiViewForCamera == ui_BtRight)
        {
            CameraHandler.Instance.RotateCameraAround(1);
        }
    }
    #endregion
}