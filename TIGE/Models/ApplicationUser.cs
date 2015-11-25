using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace TIGE.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public char Sexo { get; set; }
        public int InstituicaoID { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }

        //Propriedade de Navegação
        public virtual Instituicao Instituicao { get; set; }
        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
        public virtual ICollection<Atividade> Atividades { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}