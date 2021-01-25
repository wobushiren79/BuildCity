using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIViewForCameraZoom : BaseMonoBehaviour
{
    public Slider ui_Pro;


    private void Start()
    {
        if (ui_Pro)
        {
            ui_Pro.onValueChanged.AddListener(OnValueChangeForPro);
            ui_Pro.value = 0.5f;
        }
    }
    public void OnClickForCreate()
    {
        SceneBuildBean sceneBuild = GameDataHandler.Instance.manager.CreateNewSceneData(10, 10, 10);
        BuildHandler.Instance.InitBuild(sceneBuild);

        //初始化摄像头
        CameraHandler.Instance.InitCamera();
    }

    public void OnValueChangeForPro(float value)
    {
        CameraHandler.Instance.ZoomCameraForPro(value);
    }
}