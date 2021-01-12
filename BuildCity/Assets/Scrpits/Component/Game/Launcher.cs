using UnityEditor;
using UnityEngine;

public class Launcher : BaseMonoBehaviour
{
    private void Start()
    {
        SceneBuildBean sceneBuild = GameDataHandler.Instance.manager.CreateNewSceneData(10, 20, 10);
        BuildHandler.Instance.InitBuild(sceneBuild);
    }
}