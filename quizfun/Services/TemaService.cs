using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quizfun.Models;
using quizfun.Repos;

namespace quizfun.Services
{
    public class TemaService : ITemaService
    {
        private ITemaRepos tmsrv;
        public TemaService()
        {
            this.tmsrv = new TemaRepos();
        }

        public bool createTema(Tema t)
        {
            return tmsrv.Create(t);
        }

        public List<Tema> ReaderNomTema(string tema)
        {
            return tmsrv.ReaderNomTema(tema);
        }

        public List<Tema> ReaderTema()
        {
            return tmsrv.Reader();
        }

        public bool DeleteTema(Tema tema)
        {
            return this.tmsrv.Delete(tema);
        }

        public bool UpdateTema(Tema t)
        {
            return tmsrv.Update(t);
        }


    }
}