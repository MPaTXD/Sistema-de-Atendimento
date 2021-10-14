using Domain.Interfaces.InterfaceFormulario;
using Entites.Entites;
using Infrastructure.Configs;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository {
    public class RepositoryOrdem : RepositoryGeneric<Ordem>, IOrdem 
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryOrdem()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Ordem>> ListarOrdemPeloAtendimento(Expression<Func<Ordem, bool>> exOrdem)
        {
            using (var db = new ContextBase(_optionsBuilder) )
            {
                return await db.Ordem.Where(exOrdem).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Ordem>> ListarOrdemPeloStatus(Expression<Func<Ordem,bool>> exOrdem)
        {
            using (var db = new ContextBase(_optionsBuilder)) 
            {
                return await db.Ordem.Where(exOrdem).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Ordem>> ListarOrdemPeloSolicitante(Expression<Func<Ordem,bool>> exOrdem)
        {
            using (var db = new ContextBase(_optionsBuilder))
            {
                return await db.Ordem.Where(exOrdem).AsNoTracking().ToListAsync();
            }
        }
    }
}
