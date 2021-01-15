using UnityEditor;
using UnityEngine;

public class CameraManager : BaseManager
{
    protected Camera mainCamera;

    protected float maxOrthographicSize = 100;
    protected float minOrthographicSize = 20;
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public Camera GetMainCamera()
    {
        return mainCamera;
    }

    public void SetCameraFieldOfView(float fieldOfView)
    {
        if(fieldOfView > maxOrthographicSize)
            fieldOfView = maxOrthographicSize;
        else if (fieldOfView < minOrthographicSize)
            fieldOfView = minOrthographicSize;
        mainCamera.fieldOfView = fieldOfView;
    }
}