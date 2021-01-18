using UnityEditor;
using UnityEngine;

public class GameDataHandler : BaseHandler<GameDataHandler, GameDataManager>
{

    /// <summary>
    /// 检测指定点是否有建筑
    /// </summary>
    /// <param name="buildPosition"></param>
    /// <returns></returns>
    public bool CheckHasBuild(Vector3 buildPosition)
    {
        SceneBuildBean sceneBuild = manager.GetSceneData();
        return sceneBuild.CheckHasBuild(buildPosition);
    }

    /// <summary>
    /// 检测是否超过边界
    /// </summary>
    /// <param name="buildPosition"></param>
    /// <returns></returns>
    public bool CheckBorder(Vector3 buildPosition)
    {
        SceneBuildBean sceneBuild = manager.GetSceneData();
        if (buildPosition.x >= sceneBuild.sceneSizeX)
            return true;
        if (buildPosition.x < 0)
            return true;
        if (buildPosition.y >= sceneBuild.sceneSizeY)
            return true;
        if (buildPosition.y < 0)
            return true;
        if (buildPosition.z >= sceneBuild.sceneSizeZ)
            return true;
        if (buildPosition.z < 0)
            return true;
        return false;
    }
}