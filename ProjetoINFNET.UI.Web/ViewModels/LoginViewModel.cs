﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoINFNET.UI.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [MaxLength(30, ErrorMessage = "Máximo permitido para o Email são 30 caracteres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name ="Esqueci minha senha.")]
        public bool RememberMe { get; set; }
    }
}