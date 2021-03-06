﻿using UnityEngine;
using System.Collections;

public class AppStart : MonoBehaviour,IResourcesListener {

	// Use this for initialization
	void Awake () {

        ResourcesMgr.Create();
        SoundMgr.Create();
        UIMgr.Create();
        PhotonMgr.Create();
        MessageTipView.Create();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    UIMgr.Instance.HideUIPanel(UIDefinit.UILogin);
        //    UIMgr.Instance.ShowUIPanel(UIDefinit.UIMain);
        //    ResourcesMgr.Instance.Load("一个测试用的玩意", typeof(GameObject), this);
        //}
    }

    public void OnLoaded(string assetName, object asset)
    {
        Instantiate<GameObject>(asset as GameObject);
    }
}
