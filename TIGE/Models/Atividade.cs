using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TIGE.Models
{
    public class Atividade
    {
        public int AtividadeID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int EventoID { get; set; }
        public string UserID { get; set; }
        public int AreaID { get; set; }
        public string CargaHoraria { get; set; }  

        //Propriedade de Navegação
        public virtual Area Area { get; set; }
        public virtual Evento Evento { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser Usuario { get; set; }
        public virtual ICollection<Documento> Documento { get; set; }
    }
}