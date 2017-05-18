using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_API.Models
{
    public class Sala
    {
        public int SalaID { get; set; }

        public string Nome { get; set; }

        public string Tag { get; set; }

        public int DepartamentoID { get; set; }

        [NotMapped]
        public Departamento Departamento { get; set; }

        [NotMapped]
        public ICollection<Produto> Produtos { get; set; }
    }
}
