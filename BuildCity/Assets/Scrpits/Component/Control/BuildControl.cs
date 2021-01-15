using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildControl : BaseMonoBehaviour
{
    public enum BuildModeEnum
    {
        Null,
        Build,
        Demolition,
    }

    public BuildModeEnum buildMode = BuildModeEnum.Null;

    //建造延迟
    public float timeForBuildDelay = 0;
    public float timeForDelayTouch = 0;

    private void Update()
    {
        if (buildMode == BuildModeEnum.Build)
        {
            HandleForBuild();
        }
        else if (buildMode == BuildModeEnum.Demolition)
        {
            HandleForDemolition();
        }
        else
        {

        }
        if (timeForBuildDelay > 0)
            timeForBuildDelay -= Time.deltaTime;
    }

    /// <summary>
    /// 改变模式
    /// </summary>
    /// <param name="buildMode"></param>
    public void ChangeMode(BuildModeEnum buildMode)
    {
        this.buildMode = buildMode;
    }

    public void HandleForBuild()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //点击到了UI
            if (CheckUtil.IsPointerUI())
                return;
            timeForDelayTouch = 0.2f;
            CheckAndBuild();
        }
        if (Input.GetMouseButton(0))
        {
            //点击到了UI
            if (CheckUtil.IsPointerUI())
                return;
            if (timeForDelayTouch <= 0)
            {
                CheckAndBuild();
            }
        }
        if (timeForDelayTouch > 0)
        {
            timeForDelayTouch -= Time.deltaTime;
        }
    }

    public void HandleForDemolition()
    {        
        if (Input.GetMouseButton(0))
        {
            //点击到了UI
            if (CheckUtil.IsPointerUI())
                return;
            CheckAndDemolition();
        }
    }


    /// <summary>
    /// 检测并且修建
    /// </summary>
    public void CheckAndBuild()
    {
        if (timeForBuildDelay > 0)
            return;
        RayUtil.RayToScreenPoint(out bool isCollider, out RaycastHit hit);
        if (!isCollider)
            return;
        BuildBase buildBase = hit.collider.GetComponent<BuildBase>();
        if (buildBase != null)
        {
            //判断该点是否有建筑
            Vector3 buildPosition = buildBase.transform.position + new Vector3(0, 1, 0);
            if (!GameDataHandler.Instance.CheckHasBuild(buildPosition) && !GameDataHandler.Instance.CheckMoreThanHigh(buildPosition))
            {
                timeForBuildDelay = 0;
                BuildHandler.Instance.CreateBuildBase<BuildForBuilding>(BuildTypeEnum.Building, buildPosition);
            }
        }
    }

    /// <summary>
    /// 检测并且拆除
    /// </summary>
    public void CheckAndDemolition()
    {
        RayUtil.RayToScreenPoint(out bool isCollider, out RaycastHit hit);
        if (!isCollider)
            return;
        BuildBase buildBase = hit.collider.GetComponent<BuildBase>();
        if (buildBase != null && buildBase.buildBaseData.GetBuildType() == BuildTypeEnum.Building)
        {
            BuildHandler.Instance.DestroyBuildBase(buildBase);
        }
    }

}