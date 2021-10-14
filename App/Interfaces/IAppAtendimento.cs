using App.Interfaces.Generics;
using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces {
    public interface IAppAtendimento : IAppGeneric<Atendimento> {
        Task AddAtendimento(Ordem ordem, Funcionario funcionario);
        Task<List<Atendimento>> ListarAtendimentos();
        Task<bool> VerificarAtendimentoPeloProtocolo(long protocolo);
        Task<Atendimento> ListarAtendimentosPeloProtocolo(long protocolo);
        Task<List<Atendimento>> ListarAtendimentosPeloStatus(StatusDoAtendimento status);
    }
}
