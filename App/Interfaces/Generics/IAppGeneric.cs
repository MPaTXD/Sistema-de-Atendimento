using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces.Generics {
    public interface IAppGeneric<T> where T : class{
        Task Add(T Object);
        Task Update(T Object);
        Task Delete(T Object);
        Task<T> SearchId(int Id);
        Task<List<T>> List();
    }
}
