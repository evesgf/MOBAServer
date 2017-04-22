using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using System;
using MOBACommon.OpCode;
using MOBACommon.Dto;
using LitJson;
using Assets.MobaClient.Scripts.Data;

public class PlayerReceiver : MonoBehaviour,IReceiver {

    public MainView mainView;

    public void OnReceive(byte subCode, OperationResponse response)
    {
        switch (subCode)
        {
            case OpPlayer.GetInfo:
                int retCode = response.ReturnCode;
                if (retCode == -1)
                {
                    //非法登录
                }
                else if (retCode == -2)
                {
                    //没有角色
                    //显示创建角色面板
                    UIMgr.Instance.ShowUIPanel(UIDefinit.UICreate);
                }
                else if (retCode==0)
                {
                    //有角色
                    //角色上线
                    PlayerOnline();
                }
                break;

            case OpPlayer.Create:
                OnCreate();
                break;

            case OpPlayer.Online:
                PlayerDto dto = JsonMapper.ToObject<PlayerDto>(response[0].ToString());
                OnOnline(dto);
                break;

            default:
                break;
        }
    }

    private void OnCreate()
    {
        UIMgr.Instance.HideUIPanel(UIDefinit.UICreate);

        //创建成功后发起上线的请求
        PlayerOnline();
    }

    /// <summary>
    /// 角色上线
    /// </summary>
    private void PlayerOnline()
    {
        PhotonMgr.Instance.Request(OpCode.PlayerCode, OpPlayer.Online);
    }

    /// <summary>
    /// 上线
    /// </summary>
    /// <param name="dto"></param>
    private void OnOnline(PlayerDto dto)
    {
        GameData.Player = dto;

        FindObjectOfType<MainView>().UpdateView(dto);
    }
}
