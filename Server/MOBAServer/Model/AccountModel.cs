using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBAServer.Model
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public AccountModel()
        {

        }

        public AccountModel(int id,string account, string password)
        {
            Id = id;
            Account = account;
            Password = password;
        }
    }
}
