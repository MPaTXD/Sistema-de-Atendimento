using App.Interfaces;
using Domain.Interfaces.InterfaceEstado;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Apps {
    public class AppEstado : IAppEstado {

        IEstado _IEstado;
        IServiceEstado _IServiceEstado;

        public AppEstado(IEstado IEstado, IServiceEstado IServiceEstado) {
            _IEstado = IEstado;
            _IServiceEstado = IServiceEstado;
        }

        public async Task AddEstado(Estado estado) {
            await _IServiceEstado.AddEstado(estado);
        }

        public async Task UpdateEstado(Estado estado) {
            await _IServiceEstado.UpdateEstado(estado);
        }

        public async Task Add(Estado Object) {
            await _IEstado.Add(Object);
        }

        public async Task Delete(Estado Object) {
            await _IEstado.Delete(Object);
        }

        public async Task<List<Estado>> List() {
            return await _IEstado.List();
        }

        public async Task<Estado> SearchId(int Id) {
            return await _IEstado.SearchId(Id);
        }

        public async Task Update(Estado Object) {
            await _IEstado.Update(Object);
        }
    }
}
