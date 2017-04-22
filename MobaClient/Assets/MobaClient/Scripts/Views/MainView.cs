using UnityEngine;
using System.Collections;
using System;
using MOBACommon.OpCode;
using UnityEngine.UI;
using MOBACommon.Dto;

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

    #region 刷新模块
    [Header("刷新")]
    [SerializeField]
    private Text txtName;
    [SerializeField]
    private Slider barExp;
    [SerializeField]
    private Transform friendTran;

    /// <summary>
    /// 更新显示
    /// </summary>
    public void UpdateView(PlayerDto dto)
    {
        txtName.text = dto.Name;
        barExp.value =(float) dto.Exp / dto.Lv * 100;

        //TODO:好友列表
    }
    #endregion
}
