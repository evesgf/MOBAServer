using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using LarkFramework;

public class MessageTipView : SingletonMono<MessageTipView> {

    public GameObject messageTip;
    public Text message;

    /// <summary>
    /// 点击后的调用
    /// </summary>
    private Action onCompleted;

    /// <summary>
    /// 显示文字
    /// </summary>
    /// <param name="text"></param>
    /// <param name="action"></param>
    public void Show(string text,Action action=null)
    {
        messageTip.SetActive(true);
        message.text = text;
        onCompleted = action;
    }

    /// <summary>
    /// 点击确定按钮
    /// </summary>
    public void OnClick()
    {
        messageTip.SetActive(false);
        if (onCompleted != null)
        {
            onCompleted();
            onCompleted = null;
        }
    }
}
