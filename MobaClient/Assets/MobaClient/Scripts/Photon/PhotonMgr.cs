using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;

public class PhotonMgr : MonoBehaviour,IPhotonPeerListener {

    private static PhotonMgr instance;
    /// <summary>
    /// 单例组件
    /// </summary>
    public static PhotonMgr Instance { get; set; }

    /// <summary>
    /// IP地址
    /// </summary>
    public string serverAddress = "127.0.0.1:5055";
    /// <summary>
    /// 名字
    /// </summary>
    public string applicationName = "MOBA";

    /// <summary>
    /// 代表客户端
    /// </summary>
    private PhotonPeer peer;
    /// <summary>
    /// 协议
    /// </summary>
    private ConnectionProtocol protocol = ConnectionProtocol.Udp;

    private bool isConnect=false;

    void Awake()
    {
        instance = this;

        peer = new PhotonPeer(this, protocol);
        peer.Connect(serverAddress, applicationName);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isConnect)
        {
            peer.Connect(serverAddress, applicationName);
        }

        peer.Service();
    }

    void OnApplicationQuit()
    {
        peer.Disconnect();
    }

    /// <summary>
    /// 向服务器发送请求
    /// </summary>
    /// <param name="code">操作码</param>
    /// <param name="SubCode">子操作码</param>
    /// <param name="parameters">参数</param>
    public void Request(byte code,byte SubCode,params object[] parameters)
    {
        //创建参数字典
        Dictionary<byte, object> dict = new Dictionary<byte, object>();
        //指定子操作码
        dict[80] = SubCode;
        //赋值参数
        for (int i = 0; i < parameters.Length; i++)
        {
            dict[(byte)i] = parameters[i];
        }
        //发送
        peer.OpCustom(code, dict, true);
    }

    #region Photon接口
    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnEvent(EventData eventData)
    {

    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {

    }

    /// <summary>
    /// 连接状态改变
    /// </summary>
    /// <param name="statusCode"></param>
    public void OnStatusChanged(StatusCode statusCode)
    {
        print(statusCode);
        switch (statusCode)
        {
            case StatusCode.Connect:
                isConnect = true;
                break;
            case StatusCode.Disconnect:
                isConnect = false;
                break;
        }
    }
    #endregion
}
