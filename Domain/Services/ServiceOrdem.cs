
using Domain.Interfaces.InterfaceFormulario;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
    public class ServiceOrdem : IServiceOrdem {

        private readonly IOrdem _IFormulario;
       
        public ServiceOrdem(IOrdem IFormulario) {
            _IFormulario = IFormulario;
        }

        public async Task AddFormulario(Ordem formulario) {
            await _IFormulario.Add(formulario);
        }

        public async Task<List<Ordem>> ListFormulario() {
            throw new NotImplementedException();
        }

        public async Task UpdateFormulario(Ordem formulario) {
            throw new NotImplementedException();
        }
    }
}
