using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class CameraControl : BaseMonoBehaviour
{
    private Touch oldTouch1;  //上次触摸点1(手指1)  
    private Touch oldTouch2;  //上次触摸点2(手指2)  

    protected float speedForRotate = 10;
    protected float speedForHorizontalMove = 1;
    protected float speedForVerticalMove = 1;

    protected int maxAngleForVertical = 315;
    protected int mixAngleForVertical = 0;

    public void Update()
    {
        //没有触摸
        if (Input.touchCount <= 0)
            return;
        RayUtil.RayToScreenPoint(out bool isCollider, out RaycastHit hit);
        if (isCollider && hit.collider.GetComponent<BuildBase>())
            return;
        HandleForScale();
        //HandleForMove(true, true);
        HandleForRotation(true, true);
    }

    public void HandleForScale()
    {
        //如果触碰到了UI
        if (Input.touchCount != 2
            || EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)
            || EventSystem.current.IsPointerOverGameObject(Input.GetTouch(1).fingerId))
            return;
        //多点触摸, 放大缩小  
        Touch newTouch1 = Input.GetTouch(0);
        Touch newTouch2 = Input.GetTouch(1);

        //第2点刚开始接触屏幕, 只记录，不做处理  
        if (newTouch2.phase == TouchPhase.Began)
        {
            oldTouch2 = newTouch2;
            oldTouch1 = newTouch1;
            return;
        }

        //计算老的两点距离和新的两点间距离，变大要放大模型，变小要缩放模型  
        float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
        float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

        //两个距离之差，为正表示放大手势， 为负表示缩小手势  
        float offset = newDistance - oldDistance;

        //进行缩放
        float scaleFactor = -offset;

        CameraHandler.Instance.ZoomCamera(scaleFactor);

        //记住最新的触摸点，下次使用  
        oldTouch1 = newTouch1;
        oldTouch2 = newTouch2;
    }

    /// <summary>
    /// 移动处理
    /// </summary>
    /// <param name="isOpenVertical"></param>
    /// <param name="isOpenHorizontal"></param>
    public void HandleForMove(bool isOpenVertical, bool isOpenHorizontal)
    {
        //单点触摸， 水平移动
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //没有点到UI时
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                var deltaposition = Input.GetTouch(0).deltaPosition;
                float horizontal = 0;
                float vertical = 0;
                if (isOpenVertical)
                {
                    vertical = -deltaposition.y * speedForVerticalMove * Time.deltaTime;
                }
                if (isOpenHorizontal)
                {
                    horizontal = -deltaposition.x * speedForHorizontalMove * Time.deltaTime;
                }
                // CameraHandler.Instance.MoveCamera(new Vector3(horizontal, 0, vertical));
            }
        }
    }

    /// <summary>
    /// 旋转处理
    /// </summary>
    /// <param name="isOpenVertical"></param>
    /// <param name="isOpenHorizontal"></param>
    public void HandleForRotation(bool isOpenVertical, bool isOpenHorizontal)
    {
        //单点触摸， 上下旋转
        if (Input.touchCount == 1)
        {
            //没有点到UI时
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                var deltaposition = Input.GetTouch(0).deltaPosition;
                if (isOpenVertical && Math.Abs(deltaposition.y) > Math.Abs(deltaposition.x))
                {
                    CameraHandler.Instance.RotateCameraAroundY(-deltaposition.y);
                }
                if (isOpenHorizontal && Math.Abs(deltaposition.x) > Math.Abs(deltaposition.y))
                {
                    CameraHandler.Instance.RotateCameraAroundXZ(deltaposition.x);
                }
            }
        }
    }

}