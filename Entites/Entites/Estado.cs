using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites {
    public class Estado {
        [Key]
        public int IdEstado { get; set; }
        public string Nome_Estado { get; set; }
        public string Uf { get; set; }
    }
}
