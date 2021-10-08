
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

        private int Nprotocolo = 00;

        public ServiceAtendimento(IAtendimento IAtendimento) {
            _IAtendimento = IAtendimento;
        }

        public async Task AddAtendimento(Atendimento atendimento, Ordem ordem) {
            var date = GerarDate();
            var protocolo = GerarProtocolo(date.ToString());
            var validarInputDate = atendimento.ValidateDate(date.ToString(), "DAtendimento");
            var validarProtocolo = atendimento.ValidateProtocolo(protocolo, "Protocolo_Atendimento");
            if (validarInputDate && validarProtocolo) {
                atendimento.OrdemId = ordem.IdOrdem;
                atendimento.DAtendimentoAndamento = date;
                atendimento.Protocolo_Atendimento = protocolo;
                await _IAtendimento.Add(atendimento);
            }
        }

        public Task<List<Atendimento>> ListAtendimento() {
            throw new NotImplementedException();
        }

        public int GerarProtocolo(string date) {
            string[] formateDate = date.Split('/');
            string protocolo = $"{formateDate[0].ToString()}{formateDate[1].ToString()}{formateDate[2].ToString()}{Nprotocolo++}";
            return int.Parse(protocolo);
        }

        public DateTime GerarDate() {
            var date = new DateTime();
            return date;
        }
        
    }
}
