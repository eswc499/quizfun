using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quizfun.Models;

namespace quizfun.Repos
{
    interface ICursoRepos : IRepos<Curso>
    {
        List<Curso> ReaderCurso(string nomcr);
    }
}
