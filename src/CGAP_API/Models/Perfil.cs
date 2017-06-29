using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_API.Models
{
    public class Perfil
    {
        [Key]
        public int PerfilID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        
        public bool Emitir { get; set; }
        
        public bool Receber { get; set; }
        
        public bool Auditorar { get; set; }
    }
}
