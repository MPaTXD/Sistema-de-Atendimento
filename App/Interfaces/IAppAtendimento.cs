using App.Interfaces.Generics;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces {
    public interface IAppAtendimento : IAppGeneric<Atendimento> {
        Task AddAtendimento(Atendimento atendimento, Ordem formulario);
        Task<List<Atendimento>> ListAtendimento();
    }
}
