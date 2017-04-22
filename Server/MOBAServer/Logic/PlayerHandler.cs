using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using MOBACommon.OpCode;
using MOBAServer.Cache;
using MOBACommon.Dto;
using LitJson;
using MOBAServer;

namespace MOBAServer.Logic
{
    public class PlayerHandler : SingeSend, IOpHandler
    {
        private AccountCache accountCache = Caches.Account;
        private PlayerCache playerCache = Caches.Player;

        public void OnDisconnect(MobaClient client)
        {
            playerCache.OffLine(client);
        }

        public void OnRequest(MobaClient client, byte subCode, OperationRequest request)
        {
            MobaApplication.LogInfo(subCode.ToString());
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
                    OnOnline(client);
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

        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="client"></param>
        private void OnOnline(MobaClient client)
        {
            int accId = accountCache.GetId(client);
            int playerId = playerCache.GetiId(accId);

            //防止重复在线
            if (playerCache.Has(client))
            {
                MobaApplication.LogInfo("重复在线");
                return;
            }

            //上线
            playerCache.Online(client, playerId);

            var model = playerCache.GetMode(playerId);
            var dto = new PlayerDto()
            {
                Id = model.Id,
                Exp = model.Exp,
                FrientList = model.FrientList,
                HeroList=model.HeroList,
                LoseCount=model.LoseCount,
                Lv=model.Lv,
                Name=model.Name,
                Power=model.Power,
                RunCount=model.RunCount,
                WinCount=model.WinCount
            };

            Send(client, OpCode.PlayerCode, OpPlayer.Online, 0, "上线成功",JsonMapper.ToJson(dto));
        }
    }
}
