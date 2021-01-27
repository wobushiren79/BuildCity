using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class UIGameStart : BaseUIComponent, UIViewForCameraMove.ICallBack
{
    public UIViewForCameraMove ui_BtLeft;
    public UIViewForCameraMove ui_BtRight;
    public UIViewForCameraMove ui_BtUp;
    public UIViewForCameraMove ui_BtDown;

    public UIViewForCameraZoom ui_Zoom;

    public UIViewForBuildMode ui_BuildMode;

    public Button ui_BtSetting;

    private void Start()
    {
        if (ui_BtLeft)
            ui_BtLeft.SetCallBack(this);
        if (ui_BtRight)
            ui_BtRight.SetCallBack(this);
        if (ui_BtUp)
            ui_BtUp.SetCallBack(this);
        if (ui_BtDown)
            ui_BtDown.SetCallBack(this);
        if (ui_BtSetting)
            ui_BtSetting.onClick.AddListener(OnClickForSetting);
    }

    public void OnClickForSetting()
    {
        DialogBean dialogData = new DialogBean();
        DialogHandler.Instance.CreateDialog<DialogForSetting>(DialogEnum.Setting, null, dialogData);
    }

    #region 镜头移动按钮回调
    public void OnClickForCameraMove(UIViewForCameraMove uiViewForCamera)
    {
        if (uiViewForCamera == ui_BtLeft)
        {
            CameraHandler.Instance.RotateCameraAroundXZ(1);
        }
        else if (uiViewForCamera == ui_BtRight)
        {
            CameraHandler.Instance.RotateCameraAroundXZ(-1);
        }
        else if (uiViewForCamera == ui_BtUp)
        {
            CameraHandler.Instance.RotateCameraAroundY(1);
        }
        else if (uiViewForCamera == ui_BtDown)
        {
            CameraHandler.Instance.RotateCameraAroundY(-1);
        }
    }
    #endregion

}