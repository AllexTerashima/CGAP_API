﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_API.Models
{
    public class Perfil
    {
        public int PerfilID { get; set; }

        public string Nome { get; set; }

        public bool Emitir { get; set; }

        public bool Receber { get; set; }

        public bool Auditorar { get; set; }

        public virtual ICollection<Usuario> PerfilUsuarios { get; set; }
    }
}
