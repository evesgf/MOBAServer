using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOBACommon.Dto
{
    public class PlayerDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int Lv { get; set; }
        /// <summary>
        /// 经验
        /// </summary>
        public int Exp { get; set; }
        /// <summary>
        /// 战斗力
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// 胜场
        /// </summary>
        public int WinCount { get; set; }
        /// <summary>
        /// 负场
        /// </summary>
        public int LoseCount { get; set; }
        /// <summary>
        /// 逃跑场次
        /// </summary>
        public int RunCount { get; set; }

        /// <summary>
        /// 英雄列表
        /// </summary>
        private string heroList = "0,1";
        /// <summary>
        /// 好友列表
        /// </summary>
        private string frientList;

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

        public PlayerDto()
        {

        }
    }
}
