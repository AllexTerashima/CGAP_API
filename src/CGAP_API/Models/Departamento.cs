using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_API.Models
{
    public class Departamento
    {
        public Departamento()
        {
            DepartamentoSalas = new List<Sala>();
            DepartamentoUsuarios = new List<Usuario>();
        }

        [Key]
        public int DepartamentoID { get; set; }

        [Required (ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; }
        
        public virtual ICollection<Sala> DepartamentoSalas { get; set; }
        
        public virtual ICollection<Usuario> DepartamentoUsuarios { get; set; }

    }
}
