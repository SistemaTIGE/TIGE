using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIGE.Models
{
    public class Documento
    {
        public int DocumentoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string URL { get; set; }
        public int AtividadeID { get; set; }

        //Propriedade de Navegação
        public virtual Atividade Atividade { get; set; }
    }
}