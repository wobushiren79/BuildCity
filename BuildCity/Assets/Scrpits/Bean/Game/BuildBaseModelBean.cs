using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class BuildBaseModelBean
{
    /// <summary>
    /// 规则
    /// </summary>
    public BuildRuleEnum buildRule;

    /// <summary>
    /// 地面一层方块（基础层 判定为下层为地面或者地基）
    /// </summary>
    public List<GameObject> listBaseModel = new List<GameObject>();

    /// <summary>
    /// 基础方块
    /// </summary>
    public List<GameObject> listObjModel = new List<GameObject>();
}