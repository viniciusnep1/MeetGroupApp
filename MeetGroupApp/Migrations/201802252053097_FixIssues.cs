namespace MeetGroupApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixIssues : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Salas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NumeroSala = c.Int(nullable: false),
                        Pessoas = c.Int(nullable: false),
                        Computador = c.Boolean(nullable: false),
                        Internet = c.Boolean(nullable: false),
                        Televisor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
