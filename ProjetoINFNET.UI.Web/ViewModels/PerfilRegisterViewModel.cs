using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjetoINFNET.UI.Web.ViewModels
{
    public class PerfilRegisterViewModel
    {
        [Required]
        [Display(Name = "Nome do Perfil de Usuário")]
        [MaxLength(50, ErrorMessage = "Máximo permitido para o Nome são 50 caracteres!")]
        [MinLength(5, ErrorMessage = "Mínimo permitido para o Nome são 5 caracteres!")]
        public string PerfilNome { get; set; }
    }
}