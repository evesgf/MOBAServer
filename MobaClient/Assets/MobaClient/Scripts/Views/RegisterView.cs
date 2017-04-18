using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MOBACommon.OpCode;
using MOBACommon.Dto;

public class RegisterView : MonoBehaviour {

    public InputField account;
    public InputField password;

    public PhotonMgr pmgr;

    public void Register()
    {
        pmgr.Request(OpCode.AccountCode, OpAccount.Register,account.text,password.text);
    }

    public void Return()
    {
        gameObject.SetActive(false);
    }
}
