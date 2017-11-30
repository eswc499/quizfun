using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quizfun.Models;
using quizfun.Repos;
using System.Web.Mvc;

namespace quizfun.Services
{
    public class UserService : IUserService
    {
        private IUserRepos userRepos;

        public UserService()
        {
            this.userRepos = new UserRepos();
        }

        internal IUserRepos UserRepos { get => userRepos; set => userRepos = value; }

        public bool CreateUser(Cuenta user)
        {
            return userRepos.Create(user);
        }

        public bool DeleteUser(string c)
        {
            return userRepos.Delete(c);
        }

        public List<Cuenta> ReaderUser()
        {
            return userRepos.Reader();
        }

       
        public List<Cuenta> ReaderUserId(string nick)
        {
            return userRepos.ReaderNick(nick);
        }

        public bool UpdateUser(Cuenta user)
        {
            return userRepos.Update(user);
        }

        public bool Login(string nick, string password)
        {
            bool ban = false;
            Cuenta c = null;

            List<Cuenta> listcuenta = ReaderUser();

            foreach(var cnt in listcuenta)
            {
                if (cnt.Nick.CompareTo(nick) == 0 && cnt.Password.CompareTo(password) == 0)
                {
                    c = cnt;
                    ban = true;
                }
                
                if(cnt.Nick.CompareTo(nick)!=0 || cnt.Password.CompareTo(password) != 0)
                {
                    c = null;
                    ban = false;
                }   
            }

            return ban;
        }
    }
}