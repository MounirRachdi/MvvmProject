using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmProject.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public User(string log, string pass)
        {
            this.Login = log;
            this.Password = pass;

        }

        public bool CheckValidate()
        {
            if (Login != "admin" || Password != "root")
                return false;
            
                return true;
            
        }
    }
}
