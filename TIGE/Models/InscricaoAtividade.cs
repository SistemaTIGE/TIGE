using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TIGE.Models
{
    public class InscricaoAtividade
    {
        public int InscricaoAtividadeID { get; set; }
        public int UserID { get; set; }
        public int AtividadeID { get; set; }

        //Propriedade de Navegação
        public virtual Atividade Atividade { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser Usuario { get; set; }

    }
}