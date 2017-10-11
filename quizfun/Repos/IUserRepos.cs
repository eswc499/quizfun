using quizfun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizfun.Repos
{
    interface IUserRepos : IRepos<User>
    {
        List<User> ReaderId(int Id);
        List<User> ReaderId(string id);
    }
}
