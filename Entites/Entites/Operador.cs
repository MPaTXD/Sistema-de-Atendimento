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

        [Display(Name = "Matrícula")]
        public int Matricula_Operador { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome Obrigatório!")]
        public string Nome_Operador { get; set; }

        
        [Display(Name = "Atendimento")]
        [Required(ErrorMessage = "Atendimento Obrigatório!")]
        public TipoOperador Tipo { get; set; }
        public virtual ICollection<Atendimento> atendimentos { get; set; }
    }
}
