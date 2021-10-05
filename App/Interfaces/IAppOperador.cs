using App.Interfaces.Generics;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces {
    public interface IAppOperador : IAppGeneric<Operador> {
        Task AddOperador(Operador operador);
        Task UpdateOperador(Operador operador);

        Task<bool> OperadorMatricula(int matricula);

        Task<Operador> OperadorId(int Id);
    }
}
