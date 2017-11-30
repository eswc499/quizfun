namespace quizfun
{
    using quizfun.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class QuizContext : DbContext
    {
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Pregunta> Pregunta { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Tema> Tema { get; set; }
        public QuizContext()
            : base("name=QuizContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
                
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}