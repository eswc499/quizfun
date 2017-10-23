using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quizfun.Repos;
using quizfun.Models;

namespace quizfun.Services
{
    public class CursoService:ICurso
    {
        private ICursoRepos cursvc;

        public CursoService()
        {
            this.cursvc = new CursoRepos();
        }

        internal ICursoRepos cursoRepos { get => cursoRepos; set => cursoRepos=value; }
        public bool createCurso(Curso cr)
        {
            return cursvc.Create(cr);
        }

        public List<Curso> ReadAllCr()
        {
            return cursvc.Reader();
        }

        public List<Curso> ReadCurso(string nmcr)
        {
            return cursvc.ReaderCurso(nmcr);
        }

        public bool DeleteCr(string nmcr)
        {
            return cursvc.Delete(nmcr);
        }

        public bool updateCr(Curso cr)
        {
            return cursvc.Update(cr);
        }
    }
}