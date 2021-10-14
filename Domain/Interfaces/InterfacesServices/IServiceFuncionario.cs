using Domain.ViewModel;
using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices {
    public interface IServiceFuncionario  {
        Task AddFuncionario(ViewModelCadastroFuncionario funcionario);
        Task UpdateFuncionario(ViewModelCadastroFuncionario funcionario, int id);
        Task<List<Funcionario>> ListarFuncionariosPeloAtendimento(Atendimentos atendimento);
        Task<Funcionario> BuscarFuncionarioPeloId(int id);
        Task<bool> VerificarFuncionarioPelaMatricula(long matricula);
    }
}
