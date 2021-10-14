
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
    public class ServiceAtendimento : IServiceAtendimento 
    {

        private readonly IAtendimento _IAtendimento;

        public ServiceAtendimento(IAtendimento IAtendimento) 
        {
            _IAtendimento = IAtendimento;
        }

        public async Task AddAtendimento(Ordem ordem, Funcionario funcionario) 
        {
            var protocoloDoAtendimento = GerarProtocolo((int)ordem.Atendimento, funcionario.Matricula);
            if (await VerificarAtendimentoPeloProtocolo(protocoloDoAtendimento))
            {
                protocoloDoAtendimento++;
            }
            var novoAtendimento = new Atendimento
            {
                OrdemId = ordem.IdOrdem,
                FuncionarioId = funcionario.IdFuncionario,
                Protocolo = protocoloDoAtendimento,
                Status = StatusDoAtendimento.ANDAMENTO,
                DataDeLancamento = GerarData()
            };
            await _IAtendimento.Add(novoAtendimento);
        }
        public async Task<List<Atendimento>> ListarAtendimentos() 
        {
            return await _IAtendimento.ListarAtendimentos();
        }
        public long GerarProtocolo(int atendimento, long matriculaDoFuncionario) 
        {
            Random numeroAleatorio = new Random();
            string protocoloDoAtendimento = $"{atendimento}{matriculaDoFuncionario}{numeroAleatorio.Next(1,10)}";
            return long.Parse(protocoloDoAtendimento);
        }
        public DateTime GerarData() 
        {
            var data = DateTime.Now;
            return data;
        }
        public async Task<bool> VerificarAtendimentoPeloProtocolo(long protocolo)
        {
            return await _IAtendimento.VerificarAtendimentoPeloProtocolo(atendimento => atendimento.Protocolo == protocolo);
        }
        public async Task<Atendimento> ListarAtendimentosPeloProtocolo(long protocolo)
        {
            return await _IAtendimento.ListarAtendimentosPeloProtocolo(atendimento => atendimento.Protocolo == protocolo);
        }
        public async Task<List<Atendimento>> ListarAtendimentosPeloStatus(StatusDoAtendimento status)
        {
            return await _IAtendimento.ListarAtendimentosPeloStatus(atendimento => atendimento.Status == status);
        }
    }
}
