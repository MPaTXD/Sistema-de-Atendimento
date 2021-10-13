using Domain.Interfaces.Generics;
using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface IFuncionario : IGeneric<Funcionario>{
        Task<List<Funcionario>> ListarFuncionariosPeloAtendimento(Expression<Func<Funcionario, bool>> exFuncionario);
        Task<Funcionario> BuscarFuncionarioPeloId(Expression<Func<Funcionario, bool>> exFuncionario);
        Task<bool> VerificarFuncionarioPelaMatricula(Expression<Func<Funcionario, bool>> exFuncionario);
    }
}
