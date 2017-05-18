﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CGAP_SITE.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [NotMapped]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        [NotMapped]
        public IFormFile Foto { get; set; }

        public string FotoLocale { get; set; }

        public int DepartamentoID { get; set; }

        [NotMapped]
        public Departamento Departamento { get; set; }

        public int PerfilID { get; set; }

        [NotMapped]
        public Perfil Perfil { get; set; }
    }
}
