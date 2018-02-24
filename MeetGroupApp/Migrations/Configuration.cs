namespace MeetGroupApp.Migrations
{
    using MeetGroupApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MeetGroupApp.Models.MeetGroupAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MeetGroupApp.Models.MeetGroupAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Salas 1 a 5 contam com computador, tem lugar para 10 pessoas, acesso a internet, tv e webcam para vídeo conferências;
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 10, Computador = true, NumeroSala = 1, Internet = true, Televisor = true });
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 10, Computador = true, NumeroSala = 2, Internet = true, Televisor = true });
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 10, Computador = true, NumeroSala = 3, Internet = true, Televisor = true });
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 10, Computador = true, NumeroSala = 4, Internet = true, Televisor = true });
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 10, Computador = true, NumeroSala = 5, Internet = true, Televisor = true });

            //Salas 6 e 7 contam com lugares para 10 pessoas e acesso a internet;
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 10, Computador = false, NumeroSala = 6, Internet = true, Televisor = false });
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 10, Computador = false, NumeroSala = 7, Internet = true, Televisor = false });

            //Salas 8, 9 e 10 contam com computador, acesso a internet, tv e webcam para vídeo conferências e tem lugar para 3 pessoas;
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 3, Computador = true, NumeroSala = 8, Internet = true, Televisor = true });
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 3, Computador = true, NumeroSala = 9, Internet = true, Televisor = true });
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 3, Computador = true, NumeroSala = 10, Internet = true, Televisor = true });

            //Salas 11 e 12 contam com lugares para 20 pessoas;
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 20, Computador = false, NumeroSala = 11, Internet = false, Televisor = false });
            context.Salas.AddOrUpdate(new Sala() { Id = Guid.NewGuid(), Pessoas = 20, Computador = false, NumeroSala = 12, Internet = false, Televisor = false });
        }
    }
}
