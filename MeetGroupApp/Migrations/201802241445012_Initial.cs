namespace MeetGroupApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reuniaos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        DataFim = c.DateTime(nullable: false),
                        HoraFim = c.Time(nullable: false, precision: 7),
                        Sala_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salas", t => t.Sala_Id)
                .Index(t => t.Sala_Id);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NumeroSala = c.Int(nullable: false),
                        Disponibilidade = c.Boolean(nullable: false),
                        Internet = c.Boolean(nullable: false),
                        Televisor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reuniaos", "Sala_Id", "dbo.Salas");
            DropIndex("dbo.Reuniaos", new[] { "Sala_Id" });
            DropTable("dbo.Salas");
            DropTable("dbo.Reuniaos");
        }
    }
}
