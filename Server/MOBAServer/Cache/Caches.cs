﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBAServer.Cache
{
    public class Caches
    {
        public static AccountCache Account;
        public static PlayerCache Player;

        public Caches()
        {
            Account = new AccountCache();
            Player = new PlayerCache();
        }
    }
}
