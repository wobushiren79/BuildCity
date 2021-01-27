using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIViewForCameraMove : BaseMonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    protected bool isClick = false;
    protected ICallBack callBack;


    private void Update()
    {
        if (isClick && callBack != null)
            callBack.OnClickForCameraMove(this);
    }

    public void SetCallBack(ICallBack callBack)
    {
        this.callBack = callBack;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
    }

    public interface ICallBack
    {
        void OnClickForCameraMove(UIViewForCameraMove uiViewForCamera);
    }
}