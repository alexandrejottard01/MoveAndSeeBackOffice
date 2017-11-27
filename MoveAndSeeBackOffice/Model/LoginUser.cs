using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class LoginUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginUser(string userName, string password)
        {
            UserName = userName;
            if (string.IsNullOrEmpty(password))
            {
                password = "";
            }
            Password = password;
        }
    }
}
