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
            userRepos = new UserRepos();
        }

        public bool CreateSpeaker(User user)
        {
            return userRepos.Create(user);
        }

        public bool CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSpeaker(int id)
        {
            return userRepos.Delete(id);
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> ReaderSpeaker()
        {
            return userRepos.Reader();
        }

        public List<User> ReaderSpeakerCountry(int id)
        {
            return userRepos.ReaderId(id);
        }

        public List<User> ReaderUser()
        {
            throw new NotImplementedException();
        }

        public List<User> ReaderUserId(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSpeaker(User user)
        {
            return userRepos.Update(user);
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}