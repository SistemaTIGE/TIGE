using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIGE.Models
{
    public class Evento
    {
        public int EventoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Inscritivel { get; set; }
        public int InstituicaoID { get; set; }

        //Propriedade de navegação
        public virtual Instituicao Instituicao { get; set; }
        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
        public virtual ICollection<Atividade> Atividades { get; set; }
    }
}