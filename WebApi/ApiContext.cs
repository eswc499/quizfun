namespace WebApi
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApi.Models;

    public class ApiContext : DbContext
    {
        public DbSet<Cuenta> Cuenta { get; set; }
        public ApiContext()
            : base("name=ApiContext1")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}