using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CGAP_API.Models
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

        public int DepartamentoID { get; set; }

        [ForeignKey("DepartamentoID")]
        [InverseProperty("DepartamentoUsuarios")]
        public virtual Departamento Departamento { get; set; }

        public int PerfilID { get; set; }

        [ForeignKey("PerfilID")]
        [InverseProperty("PerfilUsuarios")]
        public virtual Perfil Perfil { get; set; }
    }
}
