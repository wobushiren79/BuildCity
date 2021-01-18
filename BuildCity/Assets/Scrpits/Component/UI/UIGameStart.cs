using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class UIGameStart : BaseUIComponent, UIViewForCameraMove.ICallBack
{
    public UIViewForCameraMove ui_BtLeft;
    public UIViewForCameraMove ui_BtRight;
    public UIViewForCameraMove ui_BtUp;
    public UIViewForCameraMove ui_BtDown;
    public UIViewForCameraMove ui_BtZoomIn;
    public UIViewForCameraMove ui_BtZoomOut;

    public Toggle ui_CbDemolition;

    public InputField ui_EtX;
    public InputField ui_EtY;
    public InputField ui_EtZ;
    public Button ui_BtCreate;

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
        if (ui_BtZoomIn)
            ui_BtZoomIn.SetCallBack(this);
        if (ui_BtZoomOut)
            ui_BtZoomOut.SetCallBack(this);
        if (ui_CbDemolition)
            ui_CbDemolition.onValueChanged.AddListener(OnClickForDemolition);
        if (ui_BtCreate)
            ui_BtCreate.onClick.AddListener(OnClickForCreate);
    }

    public void OnClickForCreate()
    {
        int sizeX = int.Parse(ui_EtX.text);
        int sizeY = int.Parse(ui_EtY.text);
        int sizeZ = int.Parse(ui_EtZ.text);

        SceneBuildBean sceneBuild = GameDataHandler.Instance.manager.CreateNewSceneData(sizeX, sizeY, sizeZ);
        BuildHandler.Instance.InitBuild(sceneBuild);

        //初始化摄像头
        CameraHandler.Instance.InitCamera();

    }

    #region 拆除模式回调
    public void OnClickForDemolition(bool value)
    {
        if (value)
            BuildHandler.Instance.controlForBuild.ChangeMode(BuildControlModeEnum.Demolition);
        else
            BuildHandler.Instance.controlForBuild.ChangeMode(BuildControlModeEnum.Build);
    }
    #endregion

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
        else if (uiViewForCamera == ui_BtZoomIn)
        {
            CameraHandler.Instance.ZoomCamera(-1);
        }
        else if (uiViewForCamera == ui_BtZoomOut)
        {
            CameraHandler.Instance.ZoomCamera(1);
        }
    }
    #endregion
}