﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TIGE.ViewModels.Gerenciamento
{
    public class CriarInstituicaoViewModel
    {
        [Required(ErrorMessage = "Nome da Instituição é obrigatório.")]
        [Display(Name = "Nome da Instituição")]
        public string Nome { get; set; }
    }

    public class EditarInstituicaoViewModel
    {
        public int InstituicaoID { get; set; }

        [Required(ErrorMessage = "Nome da Instituição é obrigatório.")]
        [Display(Name = "Nome da Instituição")]
        public string Nome { get; set; }
    }
}