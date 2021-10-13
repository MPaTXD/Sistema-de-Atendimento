
using Domain.Interfaces.InterfaceAtendimento;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
    public class ServiceAtendimento : IServiceAtendimento {

        private readonly IAtendimento _IAtendimento;

        public ServiceAtendimento(IAtendimento IAtendimento) {
            _IAtendimento = IAtendimento;
        }

        public async Task AddAtendimento(Atendimento atendimento, Ordem formulario) {
            
        }

        public Task<List<Atendimento>> ListAtendimento() {
            throw new NotImplementedException();
        }

        public int GerarProtocolo(string date) {
            string[] formateDate = date.Split('/');
            string protocolo = $"{formateDate[0].ToString()}{formateDate[1].ToString()}{formateDate[2].ToString()}";
            return int.Parse(protocolo);
        }

        public DateTime GerarDate() {
            var date = new DateTime();
            return date;
        }
        
    }
}
