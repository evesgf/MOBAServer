/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2017-4-10 17:32:55
 * 修改：evesgf    修改时间：2017-4-10 17:32:59
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、账号操作码定义类
 ---------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOBACommon.OpCode
{
    /// <summary>
    /// 账号操作码
    /// </summary>
    public class OpAccount
    {
        /// <summary>
        /// 登录操作
        /// </summary>
        public byte Login = 0;

        /// <summary>
        /// 注册操作
        /// </summary>
        public byte Register = 1;
    }
}
