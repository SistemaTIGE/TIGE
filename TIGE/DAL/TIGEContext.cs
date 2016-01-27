using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TIGE.Models;

namespace TIGE.DAL
{
    public class TIGEContext : IdentityDbContext<ApplicationUser>
    {
        public TIGEContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TIGEContext Create()
        {
            return new TIGEContext();
        }

        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<InscricaoAtividade> InscricoesAtividades { get; set; }
    }
}