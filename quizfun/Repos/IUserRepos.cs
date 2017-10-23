using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quizfun.Models;

namespace quizfun.Repos
{
    interface IUserRepos : IRepos<Cuenta>
    {
        List<Cuenta> ReaderNick(string nick);
    }
}
