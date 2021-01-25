﻿using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class DialogForSetting : DialogView
{
    public UIViewForSettingSizeReset ui_SizeReset;

    public Button ui_BtCleanAll;

    public override void Start()
    {
        base.Awake(); 
        if (ui_BtCleanAll)
            ui_BtCleanAll.onClick.AddListener(OnClickForCleanAll);
    }

    public void OnClickForCleanAll()
    {
        BuildHandler.Instance.manager.ClearData();
    }
}