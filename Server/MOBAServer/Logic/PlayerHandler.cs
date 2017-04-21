using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using MOBACommon.OpCode;
using MOBAServer.Cache;

namespace MOBAServer.Logic
{
    public class PlayerHandler : SingeSend, IOpHandler
    {
        private AccountCache accountCache = Caches.Account;
        private PlayerCache playerCache = Caches.Player;

        public void OnDisconnect(MobaClient client)
        {

        }

        public void OnRequest(MobaClient client, byte subCode, OperationRequest request)
        {
            switch (subCode)
            {
                case OpPlayer.GetInfo:
                    GetInfo(client);
                    break;

                case OpPlayer.Create:
                    string name = request[0].ToString();
                    OnCreate(client,name);
                    break;

                case OpPlayer.Online:
                    //TODO
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        private void GetInfo(MobaClient client)
        {
            int accId = accountCache.GetId(client);

            if (accId == -1)
            {
                Send(client, OpCode.PlayerCode, OpPlayer.GetInfo, -1, "非法登录");
                return;
            }

            if (playerCache.Has(accId))
            {
                Send(client, OpCode.PlayerCode, OpPlayer.GetInfo, 0, "存在角色");
                return;
            }
            else
            {
                Send(client, OpCode.PlayerCode, OpPlayer.GetInfo, -2, "没有角色");
                return;
            }
        }

        private void OnCreate(MobaClient client, string name)
        {
            int accId = accountCache.GetId(client);
            if (playerCache.Has(accId)) return;

            //创建
            playerCache.Create(name, accId);
            Send(client, OpCode.PlayerCode, OpPlayer.Create, 0, "创建成功");
        }
    }
}
