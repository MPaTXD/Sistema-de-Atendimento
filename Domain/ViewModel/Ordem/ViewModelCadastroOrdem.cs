using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel.Ordem
{
    public class ViewModelCadastroOrdem
    {
        public Atendimentos Atendimento { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Solicitantes Solicitante { get; set; }
    }
}
