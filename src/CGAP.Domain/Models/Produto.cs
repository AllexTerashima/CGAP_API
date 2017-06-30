using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP.Domain.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Tag { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Currency)]
        public float Valor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int SalaID { get; set; }
        public virtual Sala Sala { get; set; }
    }
}
