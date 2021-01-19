using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class BuildBaseModelBean
{
    public BuildRuleEnum buildRule;
    public List<GameObject> listObjModel = new List<GameObject>();
}