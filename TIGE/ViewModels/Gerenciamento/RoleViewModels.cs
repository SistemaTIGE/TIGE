using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TIGE.ViewModels.Gerenciamento
{
    public class RoleIndexViewModel
    {
        public string Name { get; set; }
        public int UserCount { get; set; }
    }
    
    public class ChangeRoleViewModel
    {
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "Email do usuário é obrigatório")]
        public string Email { get; set; }

        [Required]
        public string RoleOrigem { get; set; }

        [Required(ErrorMessage = "Role de destino é obrigatório")]
        public string RoleDestino { get; set; }
    }
}