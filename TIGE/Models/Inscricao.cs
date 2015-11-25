﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TIGE.Models
{
    public class Inscricao
    {
        public int InscricaoID { get; set; }
        public int UserID { get; set; }
        public int EventoID { get; set; }

        //Propriedade de Navegação
        public virtual Evento Evento { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser Usuario { get; set; }
    }
}