namespace WebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pregunta")]
    public partial class Pregunta
    {
        public int PreguntaId { get; set; }

        public string Problema { get; set; }

        public int Tiempo { get; set; }

        public string alt1 { get; set; }

        public string alt2 { get; set; }

        public string alt3 { get; set; }

        public string alt4 { get; set; }

        public string respuesta { get; set; }

        public int TemaId { get; set; }

        public virtual Tema Tema { get; set; }
    }
}
