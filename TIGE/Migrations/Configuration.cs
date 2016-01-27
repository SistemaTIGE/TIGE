namespace TIGE.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TIGE.DAL.TIGEContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TIGE.DAL.TIGEContext context)
        {
            context.Roles.AddOrUpdate(m => m.Name,
                new IdentityRole { Name = "Super" },
                new IdentityRole { Name = "Administrador" },
                new IdentityRole { Name = "Moderador" },
                new IdentityRole { Name = "Palestrante" },
                new IdentityRole { Name = "Participante" });
            context.SaveChanges();

            context.Instituicoes.AddOrUpdate(m => m.Nome,
                new Models.Instituicao { Nome = "IFRN Campus Parnamirim" },
                new Models.Instituicao { Nome = "IFRN Campus Natal-Central" });
        }
    }
}
