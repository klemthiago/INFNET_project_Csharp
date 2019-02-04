using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjetoINFNET.UI.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Máximo permitido para o Nome são 30 caracteres!")]
        [MinLength(3, ErrorMessage = "Mínimo permitido para o Nome são 3 caracteres!")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [MaxLength(30, ErrorMessage = "Máximo permitido para o E-mail são 30 caracteres!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [Required]
        [Display(Name = "Perfil Usuário")]
        public int IdPerfilUsuario { get; set; }

        [Display(Name = "Perfil Usuário")]
        public IEnumerable<SelectListItem> ComboPerfilUsuario { get; set; }
    }
}