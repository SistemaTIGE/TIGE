using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TIGE.Models
{
    public class Instituicao
    {
        public int InstituicaoID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<ApplicationUser> Usuarios { get; set; }
    }
}