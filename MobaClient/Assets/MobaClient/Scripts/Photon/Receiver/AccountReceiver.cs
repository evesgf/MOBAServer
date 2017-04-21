using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using System;
using MOBACommon.OpCode;

public class AccountReceiver : MonoBehaviour,IReceiver
{

    public void OnReceive(byte subCode, OperationResponse response)
    {
        switch (subCode)
        {
            case OpAccount.Login:
                OnLogin(response.ReturnCode,response.DebugMessage);
                break;

            case OpAccount.Register:
                OnRegister(response.ReturnCode, response.DebugMessage);
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 登录的处理
    /// </summary>
    /// <param name="retCode"></param>
    private void OnLogin(short retCode,string msg)
    {
        switch (retCode)
        {
            case 0:
                //成功 登录成功
                UIMgr.Instance.HideUIPanel(UIDefinit.UILogin);
                UIMgr.Instance.ShowUIPanel(UIDefinit.UIMain);
                break;

            case -1:
                //失败 玩家在线
                MessageTipView.Instance.Show(msg);
                break;

                case -2:
                //失败 账号密码错误
                MessageTipView.Instance.Show(msg);
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 注册的处理
    /// </summary>
    /// <param name="retCode"></param>
    private void OnRegister(short retCode,string msg)
    {
        switch (retCode)
        {
            case 0:
                //成功 注册成功

                break;

            case -1:
                //失败 账号重复
                MessageTipView.Instance.Show(msg);
                break;

            default:
                break;
        }
    }
}
