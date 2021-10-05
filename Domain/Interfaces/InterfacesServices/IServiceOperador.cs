using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices {
    public interface IServiceOperador  {
        Task AddOperador(Operador operador);
        Task UpdateOperador(Operador operador);

        Task<bool> OperadorMatricula(int matricula);

        Task<Operador> OperadorId(int Id);
    }
}
