using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOBACommon.OpCode
{
    /// <summary>
    /// 角色操作码
    /// </summary>
    public class OpPlayer
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        public const byte GetInfo = 0;

        /// <summary>
        /// 创建角色
        /// </summary>
        public const byte Create = 1;

        /// <summary>
        /// 玩家上线
        /// </summary>
        public const byte Online = 2;

        /// <summary>
        /// 添加好友
        /// </summary>
        public const byte Add = 3;
    }
}
