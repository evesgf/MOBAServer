using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using System;

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
