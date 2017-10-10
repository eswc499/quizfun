using quizfun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizfun.Services
{
    interface IUserService
    {
        bool CreateUser(User user);
        List<User> ReaderUser();
        List<User> ReaderUserId(string id);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
