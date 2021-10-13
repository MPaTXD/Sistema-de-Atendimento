using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
    public class ServiceFuncionario : IServiceFuncionario {

        private readonly IFuncionario _IFuncionario;

        public ServiceFuncionario(IFuncionario IFuncionario) {
            _IFuncionario = IFuncionario;
        }
        public ServiceFuncionario() {

        }

        public async Task AddFuncionario(Funcionario funcionario) {
            if (ValidarDadosDoFuncionario(funcionario))
            {
                var atendimentoDoFuncionario = (int)funcionario.Atendimento;
                var matriculaDoFuncionario = GerarMatriculaDoFuncionario(atendimentoDoFuncionario);
                if (await VerificarFuncionarioPelaMatricula(matriculaDoFuncionario)) {
                    matriculaDoFuncionario++;
                }
                funcionario.Matricula = matriculaDoFuncionario;
                await _IFuncionario.Add(funcionario);
            }
        }

        public async Task UpdateFuncionario(Funcionario funcionario) {
            if (ValidarDadosDoFuncionario(funcionario)) 
            {
                var funcionarioExistente = await BuscarFuncionarioPeloId(funcionario.IdFuncionario);
                if (funcionario.Atendimento != funcionarioExistente.Atendimento) {
                    var novoAtendimento = (int)funcionario.Atendimento;
                    string novaMatricula = $"{funcionarioExistente.Matricula}";
                    StringBuilder novaMatriculaVetor = new StringBuilder(novaMatricula);
                    novaMatriculaVetor.Remove(0,1);
                    novaMatriculaVetor.Insert(0, $"{novoAtendimento}");
                    funcionario.Matricula = long.Parse(novaMatriculaVetor.ToString());
                }
                await _IFuncionario.Update(funcionario);
            }
        }

       

        public bool ValidarDadosDoFuncionario(Funcionario funcionario) {
            var validarNomeDoFuncionario = funcionario.ValidarNomeDoFuncionario(funcionario.Nome);
            var validarAtendimentoDoFuncionario = funcionario.ValidarAtendimentoDoFuncionario((int)funcionario.Atendimento);
            if (validarNomeDoFuncionario && validarAtendimentoDoFuncionario) {
                return true;
            }
            return false;
        }

        public long GerarMatriculaDoFuncionario(int atendimentoDoFuncionario) {
            Random numeroAleatorio = new Random();
            var dataCadastroDoFuncionario = GerarData().ToString("yyyy/MM/dd");
            string[] dataDeCadastroFormatada = dataCadastroDoFuncionario.Split('/');
            string matriculaDoFuncionario = $"{atendimentoDoFuncionario}{dataDeCadastroFormatada[0]}{dataDeCadastroFormatada[1]}{dataDeCadastroFormatada[2]}{numeroAleatorio.Next(1,100)}";
            return long.Parse(matriculaDoFuncionario);
        }

        public DateTime GerarData() {
            var date = DateTime.Now;
            return date;
        }

        public async Task<List<Funcionario>> ListarFuncionariosPeloAtendimento(Atendimentos atendimento)
        {
            return await _IFuncionario.ListarFuncionariosPeloAtendimento(funcionario => funcionario.Atendimento == atendimento);
        }

        public async Task<Funcionario> BuscarFuncionarioPeloId(int id)
        {
            return await _IFuncionario.BuscarFuncionarioPeloId(funcionario => funcionario.IdFuncionario == id);
        }

        public async Task<bool> VerificarFuncionarioPelaMatricula(long matricula)
        {
            return await _IFuncionario.VerificarFuncionarioPelaMatricula(funcionario => funcionario.Matricula == matricula);
        }
    }
}
