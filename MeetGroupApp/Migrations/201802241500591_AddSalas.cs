namespace MeetGroupApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salas", "Pessoas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salas", "Pessoas");
        }
    }
}
