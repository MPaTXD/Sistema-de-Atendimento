using Domain.Interfaces;
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
    public class RepositoryFuncionario : RepositoryGeneric<Funcionario>, IFuncionario {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryFuncionario() {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Funcionario>> ListarFuncionariosPeloAtendimento(Expression<Func<Funcionario, bool>> exFuncionario) {
            using (var db = new ContextBase(_optionsBuilder)) 
            {
                return await db.Funcionario.Where(exFuncionario).AsNoTracking().ToListAsync();
            }
        }

        public async Task<Funcionario> BuscarFuncionarioPeloId(Expression<Func<Funcionario, bool>> exFuncionario) {
            using (var db = new ContextBase(_optionsBuilder)) 
            {
                return await db.Funcionario.Where(exFuncionario).AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public async Task<bool> VerificarFuncionarioPelaMatricula(Expression<Func<Funcionario, bool>> exFuncionario) {
            try {
                using (var db = new ContextBase(_optionsBuilder)) 
                {
                    return await db.Funcionario.Where(exFuncionario).AsNoTracking().AnyAsync();
                }
            }
            catch (Exception)
            {

                return false;
            }  
        }
    }
}
