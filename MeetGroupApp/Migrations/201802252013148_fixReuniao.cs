namespace MeetGroupApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixReuniao : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Salas", "Disponibilidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salas", "Disponibilidade", c => c.Boolean(nullable: false));
        }
    }
}
