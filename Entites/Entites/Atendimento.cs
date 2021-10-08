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
        public int Protocolo_Atendimento { get; set; }
        public DateTime DAtendimentoAndamento { get; set; }
        public DateTime DAtendimentoFinalizado { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }

        [ForeignKey("Ordem")]
        public int OrdemId { get; set; }
        public Ordem Ordem { get; set; }

        [ForeignKey("Operador")]
        public int OperadorId { get; set; }
        public Operador Operador { get; set; }
    }
}
