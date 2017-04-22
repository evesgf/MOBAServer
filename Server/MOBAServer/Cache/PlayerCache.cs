using MOBAServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGames.Threading;

namespace MOBAServer.Cache
{
    public class PlayerCache
    {
        /// <summary>
        /// 玩家ID和模型的映射
        /// </summary>
        private SynchronizedDictionary<int, PlayerModel> idModelDict = new SynchronizedDictionary<int, PlayerModel>();

        /// <summary>
        /// 账号Id对应玩家Id
        /// </summary>
        private SynchronizedDictionary<int, int> accPlayerDict = new SynchronizedDictionary<int, int>();

        /// <summary>
        /// 主键ID
        /// </summary>
        private int index = 0;

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="name"></param>
        /// <param name="accId"></param>
        public void Create(string name, int accId)
        {
            PlayerModel model = new PlayerModel(index,name,accId);
            accPlayerDict.TryAdd(accId, model.Id);
            idModelDict.TryAdd(model.Id, model);
        }

        public bool Has(int accountId)
        {
            return accPlayerDict.ContainsKey(accountId);
        }

        #region 在线
        /// <summary>
        /// 双向映射
        /// </summary>
        private SynchronizedDictionary<MobaClient, int> clientIdDict = new SynchronizedDictionary<MobaClient, int>();
        private SynchronizedDictionary<int, MobaClient> idClientDict = new SynchronizedDictionary<int, MobaClient>();

        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="client"></param>
        /// <param name="playerId"></param>
        public void Online(MobaClient client,int playerId)
        {
            clientIdDict.TryAdd(client, playerId);
            idClientDict.TryAdd(playerId, client);
        }

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="client"></param>
        public void OffLine(MobaClient client)
        {
            int id = clientIdDict[client];

            if (clientIdDict.ContainsKey(client))
                clientIdDict.Remove(client);
            if (idClientDict.ContainsKey(id))
                idClientDict.Remove(id);
        }

        public bool Has(MobaClient client)
        {
            return clientIdDict.ContainsKey(client);
        }

        public int GetiId(int accId)
        {
            int playerId = -1;
            accPlayerDict.TryGetValue(accId, out playerId);
            return playerId;
        }
        #endregion

        /// <summary>
        /// 获取玩家数据
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public PlayerModel GetMode(int playerId)
        {
            return idModelDict[playerId];
        }
    }
}
