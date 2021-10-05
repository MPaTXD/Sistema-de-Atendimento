using Domain.Interfaces.InterfaceEndereco;
using Domain.Interfaces.InterfaceEstado;
using Domain.Interfaces.InterfaceFormulario;
using Domain.Interfaces.InterfacesServices;
using Domain.Interfaces.InterfaceTelefone;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
    public class ServiceFormulario : IServiceFormulario {

        private readonly IFormulario _IFormulario;
       
        public ServiceFormulario(IFormulario IFormulario) {
            _IFormulario = IFormulario;
        }

        public async Task AddFormulario(Formulario formulario) {
            await _IFormulario.Add(formulario);
        }

        public async Task<List<Formulario>> ListFormulario() {
            throw new NotImplementedException();
        }

        public async Task UpdateFormulario(Formulario formulario) {
            throw new NotImplementedException();
        }
    }
}
