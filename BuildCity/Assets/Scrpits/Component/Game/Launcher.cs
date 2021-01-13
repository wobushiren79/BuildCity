using UnityEditor;
using UnityEngine;

public class Launcher : BaseMonoBehaviour
{
    private void Start()
    {
        //加载资源
        BuildHandler.Instance.manager.LoadBuildBaseRes( BuildTypeEnum.Building, "def");

        SceneBuildBean sceneBuild = GameDataHandler.Instance.manager.CreateNewSceneData(10, 10, 10);
        BuildHandler.Instance.InitBuild(sceneBuild);

        //初始化摄像头
        CameraHandler.Instance.InitCamera();
        //打开UI
        UIHandler.Instance.manager.OpenUI(UIEnum.GameStart);
    }
}