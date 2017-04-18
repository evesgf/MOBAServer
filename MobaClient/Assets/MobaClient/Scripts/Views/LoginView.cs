using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MOBACommon.Dto;
using MOBACommon.OpCode;
using LitJson;

public class LoginView : MonoBehaviour {

    [Header("登录模块")]
    public InputField account;
    public InputField password;

    public GameObject objRegister;

    public PhotonMgr pmgr;

    public void Login()
    {
        AccountDto dto = new AccountDto()
        {
            Account = account.text,
            Password=password.text
        };

        //发送登录请求
        pmgr.Request(OpCode.AccountCode, OpAccount.Login, JsonMapper.ToJson(dto));
    }

    public void Register()
    {
        objRegister.SetActive(true);
    }
}
