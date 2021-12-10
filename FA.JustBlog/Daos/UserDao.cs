using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Fa.JustBlog.Daos
{
    public class UserDao
    {
        DBContext myDb = new DBContext();

        public bool checkLogin(string username, string password)
        {
            var user = myDb.Users.Where(u => u.userName == username && u.password == password).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User getInformationByUserName(string username)
        {
            return myDb.Users.Where(u => u.userName == username).FirstOrDefault();
        }
    }
}