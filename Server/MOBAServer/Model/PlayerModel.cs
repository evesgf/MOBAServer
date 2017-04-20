using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBAServer.Model
{
    /// <summary>
    /// 玩家数据模型
    /// </summary>
    public class PlayerModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        private string Name { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        private int Lv { get; set; }
        /// <summary>
        /// 经验
        /// </summary>
        private int Exp { get; set; }
        /// <summary>
        /// 战斗力
        /// </summary>
        private int Power { get; set; }
        /// <summary>
        /// 胜场
        /// </summary>
        private int WinCount { get; set; }
        /// <summary>
        /// 负场
        /// </summary>
        private int LoseCount { get; set; }
        /// <summary>
        /// 逃跑场次
        /// </summary>
        private int RunCount { get; set; }
        
        public string HeroList
        {
            get
            {
                return heroList;
            }

            set
            {
                heroList = value;
            }
        }

        public string FrientList
        {
            get
            {
                return frientList;
            }

            set
            {
                frientList = value;
            }
        }

        public int AccountId
        {
            get
            {
                return accountId;
            }

            set
            {
                accountId = value;
            }
        }

        /// <summary>
        /// 英雄列表
        /// </summary>
        private string heroList = "0,1";
        /// <summary>
        /// 好友列表
        /// </summary>
        private string frientList;
        /// <summary>
        /// 账号Id
        /// </summary>
        private int accountId;

        public PlayerModel()
        {

        }

        public PlayerModel(int id,string name,int account)
        {
            Id = id;
            Name = name;
            AccountId = account;

            Lv = 1;
            Exp = 0;
            Power = 2000;
            WinCount = 0;
            LoseCount = 0;
            RunCount = 0;
            HeroList = "0,1";
            FrientList = string.Empty;
        }
    }
}
