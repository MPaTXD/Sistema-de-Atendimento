using App.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Apps {
    public class AppOperador : IAppOperador {

        IOperador _IOperador;
        IServiceOperador _IServiceOperador;

        public AppOperador(IOperador IOperador, IServiceOperador IServiceOperador) {
            _IOperador = IOperador;
            _IServiceOperador = IServiceOperador;
        }

        public async Task AddOperador(Operador operador) {
            await _IServiceOperador.AddOperador(operador);
        }

        public async Task UpdateOperador(Operador operador) {
            await _IServiceOperador.UpdateOperador(operador);
        }


        public async Task Add(Operador Object) {
            await _IOperador.Add(Object);
        }

        public async Task Delete(Operador Object) {
            await _IOperador.Delete(Object);
        }

        public async Task<List<Operador>> List() {
            return await _IOperador.List();
        }

        public async Task<Operador> SearchId(int Id) {
            return await _IOperador.SearchId(Id);
        }

        public async Task Update(Operador Object) {
            await _IOperador.Update(Object);
        }

        public async Task<bool> OperadorMatricula(int matricula) {
            return await _IOperador.OperadorMatricula(o => o.Matricula_Operador == matricula);
        }

        public async Task<Operador> OperadorId(int Id) {
            return await _IOperador.OperadorId(o => o.IdOperador == Id);
        }
    }
}
