using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_SITE.Models
{
    public class Sala
    {
        public Sala()
        {
            SalaProdutos = new List<Produto>();
        }

        [Key]
        public int SalaID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Tag { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int DepartamentoID { get; set; }

        [ForeignKey("DepartamentoID")]
        [InverseProperty("DepartamentoSalas")]
        public virtual Departamento Departamento { get; set; }

        public virtual ICollection<Produto> SalaProdutos { get; set; }
    }
}
