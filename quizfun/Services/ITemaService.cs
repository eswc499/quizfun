using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quizfun.Models;

namespace quizfun.Services
{
    interface ITemaService
    {
        bool createTema(Tema t);
        List<Tema> ReaderNomTema(string tema);
        List<Tema> ReaderTema();
        bool DeleteTema(string tema);
        bool UpdateTema(Tema t);
    }
}
