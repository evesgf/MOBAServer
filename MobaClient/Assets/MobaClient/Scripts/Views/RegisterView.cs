using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MOBACommon.OpCode;
using MOBACommon.Dto;

public class RegisterView : MonoBehaviour {

    public InputField account;
    public InputField password;

    public void Register()
    {
        PhotonMgr.Instance.Request(OpCode.AccountCode, OpAccount.Register,account,password);
    }

    public void Return()
    {
        gameObject.SetActive(false);
    }
}
