using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_SITE.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoID { get; set; }

        public string Nome { get; set; }

        public string Pais { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        [NotMapped]
        public ICollection<Sala> Salas { get; set; }

        [NotMapped]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
