using Entites.Enums;
using Entites.Notifys;
using Entites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel {
    public class ViewModelCadastroFuncionario : FuncionarioNotify
    {
        public string Nome { get; set; }
        public Atendimentos Atendimento { get; set; }
    }
}
