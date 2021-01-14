using UnityEditor;
using UnityEngine;

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
        if (Input.GetMouseButton(0))
        {
            CheckAndBuild();
        }
    }

    public void HandleForDemolition()
    {
        if (Input.GetMouseButton(0))
        {
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
            if (!GameDataHandler.Instance.CheckHasBuild(buildPosition))
            {
                timeForBuildDelay = 0.05f;
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