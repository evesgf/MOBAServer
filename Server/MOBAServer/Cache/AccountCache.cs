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
        //账号模型映射
        private Dictionary<string, AccountModel> accModelDict = new Dictionary<string, AccountModel>();

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
            //排重
            if (accModelDict.ContainsKey(acc)) return false;

            accModelDict[acc] = new AccountModel
            {
                Id=id++,
                Account = acc,
                Password = pwd
            };

            return true;
        }
    }
}
