using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using System;
using MOBACommon.OpCode;

public class PlayerReceiver : MonoBehaviour,IReceiver {

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
                }
                break;

            default:
                break;
        }
    }
}
