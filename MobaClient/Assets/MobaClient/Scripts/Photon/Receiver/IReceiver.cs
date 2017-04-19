using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;

/// <summary>
/// 收到服务器响应的接受接口
/// </summary>
public interface IReceiver
{
    /// <summary>
    /// 收到服务器的响应
    /// </summary>
    /// <param name="subCode">子操作</param>
    /// <param name="response">对应的响应</param>
    void OnReceive(byte subCode, OperationResponse response);
}
