using quizfun.Models;
using quizfun.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quizfun.Services
{
    public class UserService : IUserService
    {
        public IUserRepos userRepos;

        public UserService()
        {
            userRepos = new userRepos();
        }

        public bool CreateUser(User user)
        {
            return userRepos.Create(user);
        }

        public bool DeleteUser(int id)
        {
            return userRepos.Delete(id);
        }

        public List<User> ReaderUser()
        {
            return userRepos.Reader();
        }

        public List<User> ReaderUserId(string id)
        {
            return userRepos.ReaderId(id);
        }

        public bool UpdateUser(User user)
        {
            return userRepos.Update(user);
        }
    }
}