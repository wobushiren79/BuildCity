using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BuildBaseManager))]
public class BuildBaseEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        BuildBaseManager buildBaseEditor = (BuildBaseManager)target;
        EditorGUILayout.BeginHorizontal();
        if (EditorUI.GUIButton("添加所有"))
        {
            buildBaseEditor.AddAllRule();
        }
        if (EditorUI.GUIButton("保存"))
        {
            AssetDatabase.SaveAssets();
        }
        if (EditorUI.GUIButton("清空"))
        {
            buildBaseEditor.CleanData();
        }
        EditorGUILayout.EndHorizontal();
    }

}