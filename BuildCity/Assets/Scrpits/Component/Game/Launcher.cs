using UnityEditor;
using UnityEngine;

public class Launcher : BaseMonoBehaviour
{

    public GameObject objMirror;

    public int sizeX = 20;
    public int sizeY = 20;
    public int sizeZ = 20;

    private void Start()
    {
        //加载资源
        BuildHandler.Instance.manager.LoadBuildBaseRes(BuildTypeEnum.Building, "def");

        SceneBuildBean sceneBuild = GameDataHandler.Instance.manager.CreateNewSceneData(sizeX, sizeY, sizeZ);
        BuildHandler.Instance.InitBuild(sceneBuild);

        //初始化摄像头
        CameraHandler.Instance.InitCamera();
        //打开UI
        UIHandler.Instance.manager.OpenUI(UIEnum.GameStart);

        //设置镜面位置
        Vector3 mirrorPosition = new Vector3((sceneBuild.sceneSizeX - 1) / 2f, -1.5f, (sceneBuild.sceneSizeZ - 1) / 2f);
        objMirror.transform.position = mirrorPosition;
    }

}
