using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quizfun.Models;

namespace quizfun.Services
{
    interface ICurso
    {
        bool createCurso(Curso cr);
        List<Curso> ReadCurso(string name);
        List<Curso> ReadAllCr();
        bool updateCr(Curso cr);
        bool DeleteCr(string namecr);
    }
}
