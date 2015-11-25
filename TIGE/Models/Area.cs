using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIGE.Models
{
    public class Area
    {
        public int AreaID { get; set; }
        public string Nome { get; set; }

        //Propriedade de Navegação
        public virtual ICollection<Atividade> Atividades { get; set; }
    }
}