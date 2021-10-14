
using Domain.Interfaces.InterfaceAtendimento;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using Entites.Enums;
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

        public async Task AddAtendimento(Atendimento atendimento, Ordem ordem, Funcionario funcionario) {
            var protocoloDoAtendimento = GerarProtocolo((int)ordem.Atendimento, funcionario.Matricula);
            atendimento.Protocolo = protocoloDoAtendimento;
            atendimento.Status = StatusDoAtendimento.ANDAMENTO;
            atendimento.DataDeLancamento = GerarData();
            await _IAtendimento.Add(atendimento);
        }

        public async Task<List<Atendimento>> ListarAtendimentos() {
            return await _IAtendimento.ListarAtendimentos();
        }

        public long GerarProtocolo(int atendimento, long matriculaDoFuncionario) {
            Random numeroAleatorio = new Random();
            string protocoloDoAtendimento = $"{atendimento}{matriculaDoFuncionario}{numeroAleatorio.Next(1,100)}";
            return long.Parse(protocoloDoAtendimento);
        }

        public DateTime GerarData() {
            var data = new DateTime();
            return data;
        }
        
    }
}
