using App.Interfaces.Generics;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces {
    public interface IAppEstado : IAppGeneric<Estado> {
        Task AddEstado(Estado estado);
        Task UpdateEstado(Estado estado);
    }
}
