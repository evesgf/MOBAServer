using UnityEngine;
using System.Collections;

/// <summary>
/// UI的基类
/// </summary>
public abstract class UIBase : MonoBehaviour {

    /// <summary>
    /// UI的名称
    /// </summary>
    public abstract string uiName();

    protected  CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        Init();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// UI的显示
    /// </summary>
    public abstract void OnShow();

    /// <summary>
    /// UI的隐藏
    /// </summary>
    public abstract void OnHide();

    /// <summary>
    /// 被销毁的方法
    /// </summary>
    public abstract void OnDestroy();
}
