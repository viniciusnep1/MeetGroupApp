namespace MeetGroupApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSalaClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salas", "Computador", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salas", "Computador");
        }
    }
}
