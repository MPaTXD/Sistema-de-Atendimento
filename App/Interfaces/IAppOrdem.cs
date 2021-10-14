using App.Interfaces.Generics;
using Domain.ViewModel.Ordem;
using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces {
    public interface IAppOrdem : IAppGeneric<Ordem> {
        Task AddOrdem(ViewModelCadastroOrdem ordem);
        Task UpdateOrdem(ViewModelCadastroOrdem ordem, int id);
        Task<List<Ordem>> ListarOrdemPeloAtendimento(Atendimentos atendimento);
        Task<List<Ordem>> ListarOrdemPeloStatus(StatusDaOrdem statusDaOrdem);
        Task<List<Ordem>> ListarOrdemPeloSolicitante(Solicitantes solicitante);
    }
}
