using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices {
    public interface IServiceOrdem {
        Task AddOrdem(Ordem ordem);
        Task UpdateOrdem(Ordem ordem);
        Task<List<Ordem>> ListarOrdemPeloAtendimento(Atendimentos atendimento);
        Task<List<Ordem>> ListarOrdemPeloStatus(StatusDaOrdem statusDaOrdem);
        Task<List<Ordem>> ListarOrdemPeloSolicitante(Solicitantes solicitante);
    }
}
