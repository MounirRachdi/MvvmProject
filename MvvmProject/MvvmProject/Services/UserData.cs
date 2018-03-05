using MvvmProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace MvvmProject.Services
{
    public class UserData
    {
        User user = new User("", "");
        public string GetLogin()
        {
            return user.Login = "admin";


        }

        public string GetPassword()
        {

            return user.Password = "root";
        }
    }
}
