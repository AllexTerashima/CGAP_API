using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CGAP.Domain.Models
{
    public class Usuario 
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int DepartamentoID { get; set; }
        public virtual Departamento Departamento { get; set; }

        public bool Emitir { get; set; }

        public bool Receber { get; set; }

        public bool Auditorar { get; set; }
    }
}
