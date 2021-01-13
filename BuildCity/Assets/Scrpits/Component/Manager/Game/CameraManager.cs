using UnityEditor;
using UnityEngine;

public class CameraManager : BaseManager
{
    protected Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public Camera GetMainCamera()
    {
        return mainCamera;
    }

}