using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Notifys {
    public class AtendimentoNotify {

        public AtendimentoNotify() {
            Notifys = new List<AtendimentoNotify>();
        }

        [NotMapped]
        private string _Mensagem { get; set; }
        public string Mensagem => _Mensagem;

        [NotMapped]
        public List<AtendimentoNotify> Notifys;

       
    }
}
