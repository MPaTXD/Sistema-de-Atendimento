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
    
    public class Atendimento : AtendimentoNotify {
        [Key]
        public int IdAtendimento { get; set; }

        [ForeignKey("Formulario")]
        public int FormularioId { get; set; }
        public Formulario Formulario { get; set; }

        [ForeignKey("Operador")]
        public int OperadorId { get; set; }
        public Operador Operador { get; set; }

        [Display(Name = "AREA DO ATENDIMENTO")]
        public AreaAtendimento AreaAtendimento { get; set; }

        [Display(Name = "PROTOCOLO")]
        public int Protocolo_Atendimento { get; set; }

        [Display(Name = "DATA DO ATENDIMENTO")]
        public DateTime DAtendimento { get; set; }

    }
}
