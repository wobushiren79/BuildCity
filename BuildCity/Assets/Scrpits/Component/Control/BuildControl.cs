using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildControl : BaseMonoBehaviour
{

    public BuildControlModeEnum buildMode = BuildControlModeEnum.Null;

    //建造延迟
    public float timeForBuildDelay = 0;
    public float timeForDelayTouch = 0;

    private void Update()
    {
        if (buildMode == BuildControlModeEnum.Build)
        {
            HandleForBuild(); 
        }
        else if (buildMode == BuildControlModeEnum.Demolition)
        {
            HandleForDemolition();
        }
        else
        {

        }
        if (timeForBuildDelay > 0)
            timeForBuildDelay -= Time.deltaTime;
        if (timeForDelayTouch > 0)
            timeForDelayTouch -= Time.deltaTime;
    }

    /// <summary>
    /// 改变模式
    /// </summary>
    /// <param name="buildMode"></param>
    public void ChangeMode(BuildControlModeEnum buildMode)
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
            if (timeForDelayTouch > 0)
                return;
            CheckAndBuild();
        }

    }

    public void HandleForDemolition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //点击到了UI
            if (CheckUtil.IsPointerUI())
                return;
            timeForDelayTouch = 0.2f;
            CheckAndDemolition();
        }
        if (Input.GetMouseButton(0))
        {
            //点击到了UI
            if (CheckUtil.IsPointerUI())
                return;
            if (timeForDelayTouch > 0)
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
            Vector3 hitPosition = hit.point;
            Vector3 offsetPosition = new Vector3(0, 0, 0);
            Vector3 buildPosition = buildBase.transform.position;
            if (hitPosition.x == buildPosition.x + 0.5f)
            {
                offsetPosition = new Vector3(1, 0, 0);
            }
            else if (hitPosition.x == buildPosition.x - 0.5f)
            {
                offsetPosition = new Vector3(-1, 0, 0);
            }
            else if (hitPosition.y == buildPosition.y + 0.5f)
            {
                offsetPosition = new Vector3(0, 1, 0);
            }
            else if (hitPosition.y == buildPosition.y - 0.5f)
            {
                offsetPosition = new Vector3(0, -1, 0);
            }
            else if (hitPosition.z == buildPosition.z + 0.5f)
            {
                offsetPosition = new Vector3(0, 0, 1);
            }
            else if (hitPosition.z == buildPosition.z - 0.5f)
            {
                offsetPosition = new Vector3(0, 0, -1);
            }
            //判断该点是否有建筑
            Vector3 newBuildPosition = buildPosition + offsetPosition;
            if (!GameDataHandler.Instance.CheckHasBuild(newBuildPosition) && !GameDataHandler.Instance.CheckBorder(newBuildPosition))
            {
                timeForBuildDelay = 0;
                BuildHandler.Instance.CreateBuildBase<BuildForBuilding>(BuildTypeEnum.Building, newBuildPosition);
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