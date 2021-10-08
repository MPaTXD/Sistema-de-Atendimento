using App.Interfaces.Generics;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces {
    public interface IAppOrdem : IAppGeneric<Ordem> {
        Task AddOrdem(Ordem ordem);
        Task UpdateOrdem(Ordem ordem);
    }
}
