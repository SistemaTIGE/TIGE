using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIGE.Models
{
    public enum TipoEvento
    {
        Publico,
        Interno,
        Privado
    }

    public class Evento
    {
        public int EventoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LogoURL { get; set; }
        public bool Inscritivel { get; set; }
        public TipoEvento Tipo { get; set; }
        public int InstituicaoID { get; set; }

        //Propriedade de navegação
        public virtual Instituicao Instituicao { get; set; }
        public virtual ICollection<Inscricao> Inscricoes { get; set; }
        public virtual ICollection<Atividade> Atividades { get; set; }
    }
}