using UnityEngine;
using System.Collections;
using System;
using MOBACommon.OpCode;

public class MainView : UIBase
{
    #region UIBase
    public override void Init()
    {
        //向服务器获取角色信息
        PhotonMgr.Instance.Request(OpCode.PlayerCode, OpPlayer.GetInfo);
    }

    public override void OnDestroy()
    {

    }

    public override void OnHide()
    {

    }

    public override void OnShow()
    {

    }

    public override string uiName()
    {
        return UIDefinit.UIMain;
    }
    #endregion
}
