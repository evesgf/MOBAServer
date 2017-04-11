using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotonHostRuntimeInterfaces;
using MOBAServer.Logic;
using MOBACommon.OpCode;

namespace MOBAServer
{
    public class MobaClient : ClientPeer
    {
        //账号逻辑
        IOpHandler account;

        public MobaClient(InitRequest initRequest) : base(initRequest)
        {

        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        /// <param name="reasonCode"></param>
        /// <param name="reasonDetail"></param>
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            account.OnDisconnect(this);
        }

        /// <summary>
        /// 客户端请求
        /// </summary>
        /// <param name="operationRequest"></param>
        /// <param name="sendParameters"></param>
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            byte opCode = operationRequest.OperationCode;
            byte subCode = (byte)operationRequest[80];

            switch (opCode)
            {
                case OpCode.AccountCode:
                    account.OnRequest(this, subCode, operationRequest);
                    break;

                default:
                    break;
            }
        }
    }
}
