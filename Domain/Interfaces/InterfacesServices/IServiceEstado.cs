using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices {
    public interface IServiceEstado {
        Task AddEstado(Estado estado);
        Task UpdateEstado(Estado estado);
    }
}
