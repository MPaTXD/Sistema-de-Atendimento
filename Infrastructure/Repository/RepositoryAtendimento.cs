using Domain.Interfaces.InterfaceAtendimento;
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
    public class RepositoryAtendimento : RepositoryGeneric<Atendimento>, IAtendimento {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryAtendimento() {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<List<Atendimento>> ListarAtendimentos(Expression<Func<Atendimento, bool>> exAtendimento) 
        {
            using (var db = new ContextBase(_optionsBuilder)) 
            {
                return await db.Atendimento.Where(exAtendimento).Include(ordem => ordem.Ordem).Include(funcionario => funcionario.Funcionario).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Atendimento>> ListarAtendimentosPeloStatus()
        {
            using (var db = new ContextBase(_optionsBuilder))
            {
                return await db.Atendimento.Include(ordem => ordem.Ordem).Include(funcionario => funcionario.Funcionario).AsNoTracking().ToListAsync();
            }
        }

        public async Task<bool> VerificarAtendimentoPeloProtocolo(Expression<Func<Atendimento, bool>> exAtendimento)
        {
            try
            {
                using (var db = new ContextBase(_optionsBuilder))
                {
                    return await db.Atendimento.Where(exAtendimento).AsNoTracking().AnyAsync();
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
