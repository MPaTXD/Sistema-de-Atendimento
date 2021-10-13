using Entites.Enums;
using Entites.Notifys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites {
    
    public class Formulario : FormularioNotify {
        [Key]
        public int IdFormulario { get; set; }

        [Display(Name = "TIPO DO ATENDIMENTO")]
        public TipoFormulario TipoFomulario { get; set; }

        public string Email { get; set; }
        public string Motivo_Contato { get; set; }


        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Genero Genero { get; set; }
        public DateTime DNascimento { get; set; }


        public string Razao_social { get; set; }
        public string Nome_fantasia { get; set; }
        public string Cpnj { get; set; }
        public string Fundacao { get; set; }
        

    }
}
