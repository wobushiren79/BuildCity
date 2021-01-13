using UnityEditor;
using UnityEngine;

public class CameraHandler : BaseHandler<CameraHandler, CameraManager>
{
    protected Vector3 sceneCenterPosition = Vector3.zero;

    /// <summary>
    /// 初始化摄像头
    /// </summary>
    public void InitCamera()
    {
        Camera camera = manager.GetMainCamera();
        SceneBuildBean sceneBuild = GameDataHandler.Instance.manager.GetSceneData();
        sceneCenterPosition = new Vector3((sceneBuild.sceneSizeX - 1) / 2f, 0, (sceneBuild.sceneSizeZ - 1) / 2f);
        camera.transform.position = new Vector3((sceneBuild.sceneSizeX - 1) / 2f, sceneBuild.sceneSizeY, -(sceneBuild.sceneSizeZ - 1));
        camera.transform.LookAt(sceneCenterPosition);
    }

    /// <summary>
    /// 围绕场景中心点旋转摄像头
    /// </summary>
    /// <param name="direction"></param>
    public void RotateCameraAround(int direction)
    {
        Camera camera = manager.GetMainCamera();
        camera.transform.RotateAround(sceneCenterPosition, new Vector3(0, 1, 0), direction * Time.deltaTime * 30);
    }
}