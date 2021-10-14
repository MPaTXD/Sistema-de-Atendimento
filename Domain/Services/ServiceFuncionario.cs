using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Domain.ViewModel;
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

        public async Task AddFuncionario(ViewModelCadastroFuncionario funcionario) {
            if (ValidarDadosDoFuncionario(funcionario))
            {
                var atendimentoDoFuncionario = (int)funcionario.Atendimento;
                var matriculaDoFuncionario = GerarMatriculaDoFuncionario(atendimentoDoFuncionario);
                if (await VerificarFuncionarioPelaMatricula(matriculaDoFuncionario)) {
                    matriculaDoFuncionario++;
                }
                var novoFuncionario = new Funcionario
                {
                    Nome = funcionario.Nome,
                    Matricula = matriculaDoFuncionario,
                    Atendimento = funcionario.Atendimento
                };
                await _IFuncionario.Add(novoFuncionario);
            }
        }

        public async Task UpdateFuncionario(ViewModelCadastroFuncionario funcionario, int id) {
            if (ValidarDadosDoFuncionario(funcionario)) 
            {
                var funcionarioExistente = await BuscarFuncionarioPeloId(id);
                if (funcionario.Atendimento != funcionarioExistente.Atendimento) {
                    var novoAtendimento = (int)funcionario.Atendimento;
                    string novaMatricula = $"{funcionarioExistente.Matricula}";
                    StringBuilder novaMatriculaVetor = new StringBuilder(novaMatricula);
                    novaMatriculaVetor.Remove(0,1);
                    novaMatriculaVetor.Insert(0, $"{novoAtendimento}");
                    funcionarioExistente.Matricula = long.Parse(novaMatriculaVetor.ToString());
                    funcionarioExistente.Nome = funcionario.Nome;
                    funcionarioExistente.Atendimento = funcionario.Atendimento;
                }
                await _IFuncionario.Update(funcionarioExistente);
            }
        }

       
        public bool ValidarDadosDoFuncionario(ViewModelCadastroFuncionario funcionario) {
            var validarNomeDoFuncionario = funcionario.ValidarNomeDoFuncionario(funcionario.Nome);
            var validarAtendimentoDoFuncionario = funcionario.ValidarAtendimentoDoFuncionario((int)funcionario.Atendimento);
            if (validarNomeDoFuncionario && validarAtendimentoDoFuncionario) {
                return true;
            }
            return false;
        }

        public long GerarMatriculaDoFuncionario(int atendimentoDoFuncionario) {
            Random numeroAleatorio = new Random();
            var dataCadastroDoFuncionario = GerarData().ToString("yyyy");
            string matriculaDoFuncionario = $"{atendimentoDoFuncionario}{dataCadastroDoFuncionario}{numeroAleatorio.Next(1,100)}";
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
