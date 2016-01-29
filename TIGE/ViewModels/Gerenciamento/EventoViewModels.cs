using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TIGE.ViewModels.Gerenciamento
{
    public class CriarEventoViewModel
    {
        public enum TipoEvento
        {
            Publico,
            Interno,
            Privado
        }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Instituição é obrigatório")]
        public int InstituicaoID { get; set; }

        [Required(ErrorMessage = "Descreva o evento em algumas palavras.")]
        public string Descricao { get; set; }

        public bool Inscritivel { get; set; }

        public TipoEvento Tipo { get; set; }
    }

    public class EditarEventoViewModel
    {
        public enum TipoEvento
        {
            Publico,
            Interno,
            Privado
        }

        public int EventoID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Instituição é obrigatório")]
        public int InstituicaoID { get; set; }

        [Required(ErrorMessage = "Descreva o evento em algumas palavras.")]
        public string Descricao { get; set; }

        public bool Inscritivel { get; set; }

        public TipoEvento Tipo { get; set; }
    }
}