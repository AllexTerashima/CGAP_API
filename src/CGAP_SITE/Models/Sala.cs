using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_SITE.Models
{
    public class Sala
    {
        [Key]
        public int SalaID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Tag { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int DepartamentoID { get; set; }

        [NotMapped]
        public Departamento Departamento { get; set; }

        [NotMapped]
        public ICollection<Produto> Produtos { get; set; }
    }
}
