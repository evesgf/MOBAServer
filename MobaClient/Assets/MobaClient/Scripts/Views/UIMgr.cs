using UnityEngine;
using System.Collections;
using LarkFramework;
using System.Collections.Generic;
using System;

/// <summary>
/// UI管理类
/// </summary>
public class UIMgr : SingletonMono<UIMgr>,IResourcesListener {
    private Dictionary<string, UIBase> nameUIDict = new Dictionary<string, UIBase>();

    /// <summary>
    /// 添加UI
    /// </summary>
    /// <param name="ui"></param>
    public void AddUI(UIBase ui)
    {
        if (ui == null) return;

        nameUIDict.Add(ui.name, ui);
    }

    /// <summary>
    /// 删除UI
    /// </summary>
    public void RemoveUI(UIBase ui)
    {
        if (ui == null) return;
        if (nameUIDict.ContainsValue(ui)) return;

        nameUIDict.Remove(ui.uiName());
    }

    /// <summary>
    /// 显示UI，没有则创建
    /// </summary>
    /// <param name="uiName"></param>
    public void ShowUIPanel(string uiName)
    {
        if (nameUIDict.ContainsKey(uiName))
        {
            UIBase ui = nameUIDict[uiName];
            ui.OnShow();
            return;
        }

        ResourcesMgr.Instance.Load(uiName, typeof(GameObject), this);
    }

    public void OnLoaded(string assetName, object asset)
    {
        var uiPrefab = Instantiate<GameObject>(asset as GameObject);
        var ui=uiPrefab.GetComponent<UIBase>();
        ui.OnShow();

        AddUI(ui);
    }

    /// <summary>
    /// 关闭
    /// </summary>
    public void HideUIPanel(string uiName)
    {
        if (!nameUIDict.ContainsKey(uiName)) return;

        UIBase ui = nameUIDict[uiName];
        ui.OnHide();

        RemoveUI(ui);
    }
}
