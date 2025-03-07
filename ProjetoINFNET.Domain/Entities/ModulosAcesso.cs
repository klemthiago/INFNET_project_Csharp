﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoINFNET.Domain.Entities
{
    public partial class ModulosAcesso
    {
        public ModulosAcesso()
        {
            this.PerfisUsuario = new List<PerfilUsuario>();
        }
        [Key]
        public int IdModulo { get; set; }
        public string NomeModulo { get; set; }
        public string NomeMenuAcesso { get; set; }
        public string UrlMenu { get; set; }
        public bool FlAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? IdModuloPai { get; set; }
        public virtual ICollection<ModulosAcesso> ModulosAcessos { get; set; }
        public virtual ICollection<PerfilUsuario> PerfisUsuario { get; set; }
    }
}