using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP.Domain.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; }
    }
}
