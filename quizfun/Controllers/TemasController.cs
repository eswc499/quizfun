using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using quizfun;
using quizfun.Models;

namespace quizfun.Controllers
{
    public class TemasController : ApiController
    {
        
        QuizContext db = new QuizContext();

        //GET: api/Temas
            public IQueryable<Tema> GetTema()
        {
            return db.Tema;
        }

        // GET: api/Temas/5
        [ResponseType(typeof(Tema))]
        public IHttpActionResult GetTema(int id)
        {
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return NotFound();
            }

            return Ok(tema);
        }

        // PUT: api/Temas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTema(int id, Tema tema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tema.TemaId)
            {
                return BadRequest();
            }

            db.Entry(tema).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Temas
        [ResponseType(typeof(Tema))]
        public IHttpActionResult PostTema(Tema tema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tema.Add(tema);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tema.TemaId }, tema);
        }

        // DELETE: api/Temas/5
        [ResponseType(typeof(Tema))]
        public IHttpActionResult DeleteTema(int id)
        {
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return NotFound();
            }

            db.Tema.Remove(tema);
            db.SaveChanges();

            return Ok(tema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TemaExists(int id)
        {
            return db.Tema.Count(e => e.TemaId == id) > 0;
        }
    }
}
