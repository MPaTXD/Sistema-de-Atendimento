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
                if (await VerificarFuncionarioPelaMatricula(matriculaDoFuncionario)) 
                {
                    matriculaDoFuncionario++;
                    if (await VerificarFuncionarioPelaMatricula(matriculaDoFuncionario))
                    {
                        matriculaDoFuncionario++;
                    }
                }
                var novoFuncionario = CriarFuncionario(funcionario, matriculaDoFuncionario);
                novoFuncionario.Matricula = matriculaDoFuncionario;
                await _IFuncionario.Add(novoFuncionario);
            }
        }
        public async Task UpdateFuncionario(ViewModelCadastroFuncionario funcionario, int id) 
        {
            if (ValidarDadosDoFuncionario(funcionario)) 
            {
                var funcionarioExistente = await BuscarFuncionarioPeloId(id);
                if (funcionario.Atendimento != funcionarioExistente.Atendimento) {
                    funcionarioExistente.Matricula = AtualizarMatriculaDoFuncionario(funcionario, funcionarioExistente);
                }
                var funcionarioAtualizado = AtualizarFuncionario(funcionario, funcionarioExistente);
                await _IFuncionario.Update(funcionarioAtualizado);
            }
        }
        public Funcionario CriarFuncionario(ViewModelCadastroFuncionario funcionario, long matriculaDoFuncionario)
        {
            var novoFuncionario = new Funcionario
            {
                Matricula = matriculaDoFuncionario,
                Nome = funcionario.Nome,
                Atendimento = funcionario.Atendimento
            };
            return novoFuncionario;
        }
        public Funcionario AtualizarFuncionario(ViewModelCadastroFuncionario funcionario, Funcionario funcionarioExistente)
        {
            var novoFuncionario = new Funcionario
            {
                IdFuncionario = funcionarioExistente.IdFuncionario,
                Matricula = funcionarioExistente.Matricula,
                Nome = funcionario.Nome,
                Atendimento = funcionario.Atendimento
            };
            return novoFuncionario;
        }
        public long AtualizarMatriculaDoFuncionario(ViewModelCadastroFuncionario funcionario, Funcionario funcionarioExistente)
        {
              var novoAtendimento = (int)funcionario.Atendimento;
              string matriculaDoFuncionario = $"{funcionarioExistente.Matricula}";
              StringBuilder vetorMatriculaDoFuncionario = new StringBuilder(matriculaDoFuncionario);
              vetorMatriculaDoFuncionario.Remove(0, 1);
              vetorMatriculaDoFuncionario.Insert(0, $"{novoAtendimento}");
              var novaMatriculaDoFuncionario = long.Parse(vetorMatriculaDoFuncionario.ToString());
              return novaMatriculaDoFuncionario;
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
