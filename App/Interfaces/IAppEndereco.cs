using App.Interfaces.Generics;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces {
    public interface IAppEndereco : IAppGeneric<Endereco>{
        Task AddEndereco(Endereco endereco);
        Task UpdateEndereco(Endereco endereco);
    }
}
