namespace quizfun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pregunta",
                c => new
                {
                    PreguntaId = c.Int(nullable: false, identity: true),
                    Problema = c.String(),
                    Tiempo = c.Int(nullable: false),
                    alt1 = c.String(),
                    alt2 = c.String(),
                    alt3 = c.String(),
                    alt4 = c.String(),
                    respuesta = c.String(),
                    TemaId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PreguntaId)
                .ForeignKey("dbo.Tema", t => t.TemaId, cascadeDelete: true)
                .Index(t => t.TemaId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pregunta", "TemaId", "dbo.Tema");
            DropForeignKey("dbo.Tema", "CursoId", "dbo.Curso");
            DropIndex("dbo.Tema", new[] { "CursoId" });
            DropIndex("dbo.Pregunta", new[] { "TemaId" });
            DropTable("dbo.Curso");
            DropTable("dbo.Tema");
            DropTable("dbo.Pregunta");
        }
    }
}
