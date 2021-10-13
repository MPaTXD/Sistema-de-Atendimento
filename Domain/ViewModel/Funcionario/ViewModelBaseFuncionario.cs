using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.ViewModel {
    public class ViewModelBaseFuncionario {

        public int IdFuncionario { get; set; }
        public long Matricula { get; set; }
        public string Nome { get; set; }
        public Atendimentos Atendimento { get; set; }
    }
}
