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
    
    public class Ordem
    {
        [Key]
        public int IdOrdem { get; set; }
        public Atendimentos Atendimento { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Solicitantes Solicitante { get; set; }
        public StatusDaOrdem Status { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public DateTime DataDeConclusao { get; set; }
    }
}
