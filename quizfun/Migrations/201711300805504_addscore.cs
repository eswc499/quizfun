namespace quizfun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addscore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cuenta", "score", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cuenta", "score");
        }
    }
}
