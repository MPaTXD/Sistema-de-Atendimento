using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entites.Notifys {
    public class OrdemNotify {
        public OrdemNotify() {
            Notifys = new List<OrdemNotify>();
        }
        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<OrdemNotify> Notifys;

       
    }
}
