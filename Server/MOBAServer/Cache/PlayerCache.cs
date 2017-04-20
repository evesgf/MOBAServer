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
    }
}
