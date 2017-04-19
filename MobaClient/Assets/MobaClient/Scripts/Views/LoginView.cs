﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MOBACommon.Dto;
using MOBACommon.OpCode;
using LitJson;
using System;

public class LoginView : MonoBehaviour,IResourcesListener {

    [Header("登录模块")]
    public InputField account;
    public InputField password;

    public GameObject objRegister;

    public PhotonMgr pmgr;

    #region music 2017-4-20 00:11:03
    private AudioClip bgClip;
    private AudioClip clickClip;
    #endregion

    private void Start()
    {
        ResourcesMgr.Instance.Load(Paths.RES_SOUND_UI+"bgm", typeof(AudioClip), this);
        ResourcesMgr.Instance.Load(Paths.RES_SOUND_UI + "click", typeof(AudioClip), this);
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
        pmgr.Request(OpCode.AccountCode, OpAccount.Login, JsonMapper.ToJson(dto));
    }

    public void Register()
    {
        SoundMgr.Instance.PlayEffectMusic(clickClip);
        objRegister.SetActive(true);
    }
}
