using Domain.ViewModel.Ordem;
using Entites.Enums;
using Entites.Notifys;
using Entites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel.Atendimento
{
    public class ViewModelBaseAtendimento
    {
        public int IdAtendimento { get; set; }
        public long Protocolo { get; set; }
        public StatusDoAtendimento Status { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public DateTime DataDeConclusao { get; set; }
        public ViewModelBaseOrdem Ordem { get; set; }
        public ViewModelBaseFuncionario Funcionario { get; set; }
    }
}
