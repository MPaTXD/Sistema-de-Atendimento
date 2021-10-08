using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.ViewModel {
    public class ViewModelOperadorAPIBase {

        public int IdOperador { get; set; }
        public int Matricula_Operador { get; set; }
        public string Nome_Operador { get; set; }
        public AreaAtendimento Atendimento { get; set; }
    }
}
