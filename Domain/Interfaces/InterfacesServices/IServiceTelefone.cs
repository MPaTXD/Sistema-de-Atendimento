using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices {
    public interface IServiceTelefone {
        Task AddTelefone(Telefone telefone);
        Task UpdateTelefone(Telefone telefone);
    }
}
