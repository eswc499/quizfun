using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


namespace quizfun.Repos
{
    public interface IRepos<T>
    {
        bool Create(T t);
        List<T> Reader();
        bool Update(T t);
        bool Delete(T t);
    }
}