using Domain.Interfaces.Generics;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceFormulario {
    public interface IOrdem : IGeneric<Ordem> 
    {
        Task<List<Ordem>> ListarOrdemPeloAtendimento(Expression<Func<Ordem, bool>> exOrdem);
        Task<List<Ordem>> ListarOrdemPeloStatus(Expression<Func<Ordem, bool>> exOrdem);
        Task<List<Ordem>> ListarOrdemPeloSolicitante(Expression<Func<Ordem, bool>> exOrdem);
    }
}
