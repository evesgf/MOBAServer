using ExitGames.Threading;
using MOBAServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBAServer.Cache
{
    /// <summary>
    /// 账号的缓存层
    /// </summary>
    public class AccountCache
    {
        #region 数据
        //账号模型映射
        private SynchronizedDictionary<string, AccountModel> accModelDict = new SynchronizedDictionary<string, AccountModel>();

        /// <summary>
        /// 匹配账号密码是否正确
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Match(string acc, string pwd)
        {
            if (!accModelDict.ContainsKey(acc)) return false;

            return accModelDict[acc].Password == pwd;
        }

        //模拟使用的Id自增
        private int id = 0;

        /// <summary>
        /// 添加账号信息
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Add(string acc, string pwd)
        {
            //重复检测
            if (Has(acc)) return false;

            accModelDict[acc] = new AccountModel
            {
                Id = id++,
                Account = acc,
                Password = pwd
            };

            return true;
        }

        /// <summary>
        /// 检测账号是否存在
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        public bool Has(string acc)
        {
            return accModelDict.ContainsKey(acc);
        }
        #endregion

        #region 在线玩家
        private SynchronizedDictionary<MobaClient, string> clientAccDict = new SynchronizedDictionary<MobaClient, string>();
        //双向映射
        private SynchronizedDictionary<string, MobaClient> accClientDict = new SynchronizedDictionary<string, MobaClient>();

        /// <summary>
        /// 检测用户是否在线
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        public bool IsOnLine(string acc)
        {
            return accClientDict.ContainsKey(acc);
        }

        /// <summary>
        /// 添加在线关系
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="client"></param>
        public bool Online(string acc, MobaClient client)
        {
            if (IsOnLine(acc)) return false;

            clientAccDict[client] = acc;
            accClientDict[acc] = client;
            return true;
        }

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="client"></param>
        public void Offline(MobaClient client)
        {
            string acc = clientAccDict[client];

            if (accClientDict.ContainsKey(acc))
                accClientDict.Remove(acc);

            if (clientAccDict.ContainsKey(client))
                clientAccDict.Remove(client);
        }
        #endregion

        /// <summary>
        /// 根据链接对象获取Id
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int GetId(MobaClient client)
        {
            if (!clientAccDict.ContainsKey(client))
                return -1;

            string account = clientAccDict[client];
            if (!accModelDict.ContainsKey(account))
                return -1;

            return accModelDict[account].Id;
        }
    }
}
