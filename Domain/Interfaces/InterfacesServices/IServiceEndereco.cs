using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices {
    public interface IServiceEndereco {
        Task AddEndereco(Endereco endereco);
        Task UpdateEndereco(Endereco endereco);
    }
}
