using Entites.Enums;
using Entites.Notifys;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites {
    public class Operador : OperadorNotify {
        [Key]
        public int IdOperador { get; set; }
        public int Matricula_Operador { get; set; }
        public string Nome_Operador { get; set; }
        public AreaAtendimento Atendimento { get; set; }
        public virtual ICollection<Atendimento> atendimentos { get; set; }
    }
}
