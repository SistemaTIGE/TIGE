using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TIGE.ViewModels
{
    public class AddInstituicaoViewModel
    {
        [Required(ErrorMessage = "Nome da Instituição é obrigatório.")]
        [Display(Name = "Nome da Instituição")]
        public string Nome { get; set; }
    }

    public class EditInstituicaoViewModel
    {
        public int InstituicaoID { get; set; }

        [Required(ErrorMessage = "Nome da Instituição é obrigatório.")]
        [Display(Name = "Nome da Instituição")]
        public string Nome { get; set; }
    }
}