using Domain.Interfaces.Generics;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface IOperador : IGeneric<Operador>{
        Task<bool> OperadorMatricula(Expression<Func<Operador, bool>> exOperador);

        Task<Operador> OperadorId(Expression<Func<Operador, bool>> exOperador);
    }
}
