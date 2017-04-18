using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using MOBACommon.OpCode;
using MOBACommon.Dto;
using LitJson;
using MOBAServer.Cache;

namespace MOBAServer.Logic
{
    public class AccountHandler :SingeSend,IOpHandler
    {
        //账号的缓存
        private AccountCache cache = Caches.Account;

        public void OnDisconnect(MobaClient client)
        {
            cache.Offline(client);
        }

        /// <summary>
        /// 收到请求时的处理
        /// </summary>
        /// <param name="client"></param>
        /// <param name="subCode"></param>
        /// <param name="request"></param>
        public void OnRequest(MobaClient client, byte subCode, OperationRequest request)
        {
            switch (subCode)
            {
                case OpAccount.Login:
                    AccountDto dto = JsonMapper.ToObject<AccountDto>(request[0].ToString());
                    //验证账号密码是否合法
                    onLogin(client,dto.Account, dto.Password);
                    break;

                case OpAccount.Register:
                    string acc = request[0].ToString();
                    string pwd = request[1].ToString();

                    //添加账号
                    onRigister(client,acc, pwd);
                    break;
            }
        }

        #region 子处理
        /// <summary>
        /// 登录处理
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="pwd"></param>
        private void onLogin(MobaClient client,string acc, string pwd)
        {
            //无效检测
            if (acc == null || pwd == null) return;
            try
            {
                //TODO:验证在线...
                if (cache.IsOnLine(acc))
                {
                    //回发消息
                    this.Send(client, OpCode.AccountCode, OpAccount.Login, -1, "此玩家已在线");
                }

                if (cache.Match(acc, pwd))
                {
                    cache.Online(acc, client);
                    //回发消息
                    this.Send(client, OpCode.AccountCode, OpAccount.Login, 0, "登录成功");
                }
                else
                {
                    //回发消息
                    this.Send(client, OpCode.AccountCode, OpAccount.Login, -1, "账号或密码错误");
                }
            }
            catch (Exception e)
            {

                //回发消息
                this.Send(client, OpCode.AccountCode, OpAccount.Login, -1, cache.ToString()+e.ToString());
            }
        }

        /// <summary>
        /// 注册处理
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="pwd"></param>
        public void onRigister(MobaClient client,string acc, string pwd)
        {
            //无效检测
            if (acc == null || pwd == null) return;
            //重复检测
            if (cache.Has(acc))
            {
                //回发消息
                this.Send(client, OpCode.AccountCode, OpAccount.Register, -1, "账号重复");
                return;
            }

            //添加用户
            cache.Add(acc, pwd);
            //回发消息
            this.Send(client, OpCode.AccountCode, OpAccount.Register, 0, "注册成功");
        }
        #endregion
    }
}
