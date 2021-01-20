using UnityEditor;
using UnityEngine;
using DG.Tweening;
public class CameraHandler : BaseHandler<CameraHandler, CameraManager>
{
    protected Vector3 sceneCenterPosition = Vector3.zero;
    protected float speedForZoom = 5;
    protected float speedForMove = 5;
    protected float maxAroundY = 70;
    protected float minAroundY = 20;
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
    public void RotateCameraAroundXZ(int direction)
    {
        RotateCameraAroundXZ((float)direction * 50);
    }
    public void RotateCameraAroundXZ(float rotateOffset)
    {
        Camera camera = manager.GetMainCamera();
        camera.transform.RotateAround(sceneCenterPosition, Vector3.up, rotateOffset * Time.deltaTime * speedForMove);
    }

    public void RotateCameraAroundY(int direction)
    {
        RotateCameraAroundY((float)direction);
    }
    public void RotateCameraAroundY(float rotateOffset)
    {
        Camera camera = manager.GetMainCamera();
        Vector3 eulerAngles = camera.transform.eulerAngles;

        if (rotateOffset > 0 && eulerAngles.x >= maxAroundY)
            return;
        if (rotateOffset < 0 && eulerAngles.x <= minAroundY)
            return;
        camera.transform.RotateAround(sceneCenterPosition, camera.transform.right, rotateOffset * Time.deltaTime * speedForMove);
    }
    /// <summary>
    /// 缩放镜头
    /// </summary>
    /// <param name="size"></param>
    public void ZoomCamera(int direction)
    {
        ZoomCamera((float)direction);
    }
    public void ZoomCamera(float zoomOffset)
    {
        Camera camera = manager.GetMainCamera();
        manager.SetCameraFieldOfView(zoomOffset * Time.deltaTime * speedForZoom + camera.fieldOfView);
    }
}