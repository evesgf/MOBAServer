using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MOBACommon.Dto;
using MOBACommon.OpCode;
using LitJson;
using System;

public class LoginView : UIBase,IResourcesListener {

    [Header("登录模块")]
    public InputField account;
    public InputField password;

    public GameObject objRegister;

    #region music 2017-4-20 00:11:03
    private AudioClip bgClip;
    private AudioClip clickClip;
    #endregion

    private void  LoadAudio()
    {
        ResourcesMgr.Instance.Load(Paths.GetSoundFullName("bgm"), typeof(AudioClip), this);
        ResourcesMgr.Instance.Load(Paths.GetSoundFullName("click"), typeof(AudioClip), this);
    }

    public void OnLoaded(string assetName, object asset)
    {
        AudioClip clip = asset as AudioClip;
        switch (assetName)
        {
            case Paths.RES_SOUND_UI + "bgm":
                bgClip = clip;
                SoundMgr.Instance.PlayBgMusic(bgClip);
                break;
            case Paths.RES_SOUND_UI+"click":
                clickClip = clip;
                break;
            default:
                break;
        }
    }

    public void Login()
    {
        AccountDto dto = new AccountDto()
        {
            Account = account.text,
            Password=password.text
        };

        SoundMgr.Instance.PlayEffectMusic(clickClip);

        //发送登录请求
        PhotonMgr.Instance.Request(OpCode.AccountCode, OpAccount.Login, JsonMapper.ToJson(dto));
    }

    public void Register()
    {
        SoundMgr.Instance.PlayEffectMusic(clickClip);
        objRegister.SetActive(true);
    }

    #region UIBase 2017-4-20 14:13:58

    public override string uiName()
    {
        return UIDefinit.UILogin;
    }

    public override void Init()
    {
        LoadAudio();
    }

    public override void OnShow()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    public override void OnHide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    public override void OnDestroy()
    {
        bgClip = null;
        clickClip = null;
    }
    #endregion
}
