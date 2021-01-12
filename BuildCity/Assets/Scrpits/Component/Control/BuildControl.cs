using UnityEditor;
using UnityEngine;

public class BuildControl : BaseMonoBehaviour
{
    private void Update()
    {
        HandleForBuild();

    }

    public void HandleForBuild()
    {
        if (Input.GetMouseButton(0))
        {
            CheckAndBuild();
        }   
    }

    public void CheckAndBuild()
    {
        RayUtil.RayToScreenPoint(out bool isCollider, out RaycastHit hit);
        if (!isCollider)
            return;
        BuildBase buildBase = hit.collider.GetComponent<BuildBase>();
        if (buildBase != null)
        {
            //判断点击是否在被点击物体的上方
            if (hit.point.y >= buildBase.transform.position.y + 1)
            {
                LogUtil.Log("hit.point.y :"+ hit.point.y+ "   buildBase.transform.position.y:" + buildBase.transform.position.y);
                //判断该点是否有建筑
                Vector3 buildPosition = buildBase.transform.position + new Vector3(0, 1, 0);
                LogUtil.Log("buildPosition:"+ buildPosition);
                if (!GameDataHandler.Instance.CheckHasBuild(buildPosition))
                {
                    LogUtil.Log("CheckHasBuild:true");
                    BuildHandler.Instance.CreateBuildBase<BuildForBuilding>(BuildTypeEnum.Building, buildPosition);
                }
            }
        }
    }
}