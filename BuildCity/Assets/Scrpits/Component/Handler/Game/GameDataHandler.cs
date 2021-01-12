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
}