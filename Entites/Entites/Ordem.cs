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
    
    public class Ordem : OrdemNotify 
    {
        [Key]
        public int IdFormulario { get; set; }
        public Atendimento Atendimento { get; set; }
        public string Motivo { get; set; }
        public string Descricao { get; set; }
        public StatusDaOrdem Status { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public DateTime DataDeConclusao { get; set; }
    }
}
