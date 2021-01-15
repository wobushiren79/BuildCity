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
    /// 检测是否超过高度
    /// </summary>
    /// <param name="buildPosition"></param>
    /// <returns></returns>
    public bool CheckMoreThanHigh(Vector3 buildPosition)
    {
        SceneBuildBean sceneBuild = manager.GetSceneData();
        if (buildPosition.y > sceneBuild.sceneSizeY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}