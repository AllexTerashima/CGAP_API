using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_API.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }

        public string Tipo { get; set; }

        public string Marca { get; set; }

        public string Tag { get; set; }

        public float Valor { get; set; }

        public int SalaID { get; set; }

        [ForeignKey("SalaID")]
        [InverseProperty("SalaProdutos")]
        public virtual Sala Sala { get; set; }
    }
}
