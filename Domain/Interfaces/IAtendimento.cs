using Domain.Interfaces.Generics;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceAtendimento {
    public interface IAtendimento : IGeneric<Atendimento> {
        Task<List<Atendimento>> ListarAtendimentos();
        Task<bool> VerificarAtendimentoPeloProtocolo(Expression<Func<Atendimento, bool>> exAtendimento);
    }
}
