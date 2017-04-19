using UnityEngine;
using System.Collections;

public interface IResourcesListener
{
    /// <summary>
    /// 加载成功
    /// </summary>
    /// <param name="asset"></param>
    void OnLoaded(string assetName, object asset);
}
