namespace MeetGroupApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveClassSala : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reuniaos", "Sala_Id", "dbo.Salas");
            DropIndex("dbo.Reuniaos", new[] { "Sala_Id" });
            AddColumn("dbo.Reuniaos", "NumeroSala", c => c.Int(nullable: false));
            AddColumn("dbo.Reuniaos", "Pessoas", c => c.Int(nullable: false));
            AddColumn("dbo.Reuniaos", "Computador", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reuniaos", "Internet", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reuniaos", "Televisor", c => c.Boolean(nullable: false));
            DropColumn("dbo.Reuniaos", "Sala_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reuniaos", "Sala_Id", c => c.Guid());
            DropColumn("dbo.Reuniaos", "Televisor");
            DropColumn("dbo.Reuniaos", "Internet");
            DropColumn("dbo.Reuniaos", "Computador");
            DropColumn("dbo.Reuniaos", "Pessoas");
            DropColumn("dbo.Reuniaos", "NumeroSala");
            CreateIndex("dbo.Reuniaos", "Sala_Id");
            AddForeignKey("dbo.Reuniaos", "Sala_Id", "dbo.Salas", "Id");
        }
    }
}
