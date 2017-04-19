using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using LarkFramework;
using MOBACommon.OpCode;

public class PhotonMgr : SingletonMono<PhotonMgr>,IPhotonPeerListener {

    #region Receivers 2017-4-19 14:42:04
    //账号
    private AccountReceiver account;
    public AccountReceiver Account
    {
        get
        {
            if (account == null)
                account = FindObjectOfType<AccountReceiver>();
            return account;
        }
    }
    #endregion

    #region Photon接口 2017-4-19 14:42:01
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

    private bool isConnect = false;
    #endregion

    void Awake()
    {
        peer = new PhotonPeer(this, protocol);
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

    /// <summary>
    /// 接收服务器的响应
    /// </summary>
    /// <param name="response"></param>
    public void OnOperationResponse(OperationResponse response)
    {
        LogMgr.Debug(response.ToStringFull());

        byte opCode = response.OperationCode;
        byte subCode = (byte)response[80];

        //转接
        switch (opCode)
        {
            case OpCode.AccountCode:
                Account.OnReceive(subCode, response);
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 连接状态改变
    /// </summary>
    /// <param name="statusCode"></param>
    public void OnStatusChanged(StatusCode statusCode)
    {
        LogMgr.Debug(statusCode.ToString());
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
