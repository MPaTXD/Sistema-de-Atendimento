using Domain.Interfaces.InterfaceEstado;
using Entites.Entites;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository {
    public class RepositoryEstado : RepositoryGeneric<Estado>, IEstado {
    }
}
