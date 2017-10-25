using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quizfun.Models;

namespace quizfun.Repos
{
    public interface ITemaRepos : IRepos<Tema>
    {
        List<Tema> ReaderNomTema(String Tema);
    }
}
