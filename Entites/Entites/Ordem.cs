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
    
    public class Ordem : OrdemNotify {
        [Key]
        public int IdOrdem { get; set; }
        public string Titulo_Ordem { get; set; }
        public string Email { get; set; }
        public string Motivo_Solicitacao { get; set; }
        public string Descricao { get; set; }
        public Solicitantes Solicitante { get; set; }
        public AreaAtendimento Atendimemto { get; set; }
        public OrdemStatus OrdemStatus { get; set; }
        public DateTime DOrdemGerada { get; set; }
        public DateTime DOrdemFinalizada { get; set; }
    }
}
