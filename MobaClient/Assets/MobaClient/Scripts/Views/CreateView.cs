using UnityEngine;
using System.Collections;
using System;
using MOBACommon.OpCode;
using UnityEngine.UI;

public class CreateView : UIBase,IResourcesListener
{

    [SerializeField]
    public Button btnCreate;

    [SerializeField]
    private InputField inName;

    private AudioClip clickClip;

    #region UIBase

    public override void Init()
    {
        btnCreate.onClick.AddListener(OnCreateClick);

        ResourcesMgr.Instance.Load(Paths.GetSoundFullName("click"), typeof(AudioClip), this);
    }

    public override void OnDestroy()
    {
        clickClip = null;
    }

    public override void OnHide()
    {

    }

    public override void OnShow()
    {
    }

    public override string uiName()
    {
        return UIDefinit.UICreate;
    }
    #endregion

    public void OnCreateClick()
    {
        //发起创建请求
        PhotonMgr.Instance.Request(OpCode.PlayerCode, OpPlayer.Create, inName.text);

        SoundMgr.Instance.PlayEffectMusic(clickClip);
    }

    public void OnLoaded(string assetName, object asset)
    {
        AudioClip clip = asset as AudioClip;
        switch (assetName)
        {
            case Paths.RES_SOUND_UI + "click":
                clickClip = clip;
                break;
            default:
                break;
        }
    }
}
