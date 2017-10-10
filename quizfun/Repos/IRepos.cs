using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizfun.Repos
{
    interface IRepos<T>
    {
        bool Create(T t);
        List<T> Reader();
        bool Update(T t);
        bool Delete(int id);
    }

}
