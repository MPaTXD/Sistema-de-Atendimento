using App.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Apps {
    public class AppFuncionario : IAppFuncionario {

        IFuncionario _IFuncionario;
        IServiceFuncionario _IServiceFuncionario;

        public AppFuncionario(IFuncionario IFuncionario, IServiceFuncionario IServiceFuncionario) {
            _IFuncionario = IFuncionario;
            _IServiceFuncionario = IServiceFuncionario;
        }

        public async Task AddFuncionario(Funcionario funcionario) {
            await _IServiceFuncionario.AddFuncionario(funcionario);
        }

        public async Task UpdateFuncionario(Funcionario funcionario) {
            await _IServiceFuncionario.UpdateFuncionario(funcionario);
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


        public async Task Add(Funcionario Object) {
            await _IFuncionario.Add(Object);
        }

        public async Task Delete(Funcionario Object) {
            await _IFuncionario.Delete(Object);
        }

        public async Task<List<Funcionario>> List() {
            return await _IFuncionario.List();
        }

        public async Task<Funcionario> SearchId(int Id) {
            return await _IFuncionario.SearchId(Id);
        }

        public async Task Update(Funcionario Object) {
            await _IFuncionario.Update(Object);
        }
    }
}
