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
    public class RepositoryOperador : RepositoryGeneric<Operador>, IOperador {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryOperador() {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        //public async Task<Operador> OperadorMatricula(Expression<Func<Operador, bool>> exOperador) {
            //using (var db = new ContextBase(_optionsBuilder)) {
                //return await db.Operador.Where(exOperador).AsNoTracking().FirstOrDefaultAsync();
            //}
        //}

        public async Task<Operador> OperadorId(Expression<Func<Operador, bool>> exOperador) {
            using (var db = new ContextBase(_optionsBuilder)) {
                return await db.Operador.Where(exOperador).AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public async Task<bool> OperadorMatricula(Expression<Func<Operador, bool>> exOperador) {
            try {
                using (var db = new ContextBase(_optionsBuilder)) {
                    return await db.Operador.Where(exOperador).AsNoTracking().AnyAsync();
                }
            }
            catch (Exception) {

                return false;
            }  
        }

        //public async Task<bool> OperadorId(Expression<Func<Operador, bool>> exOperador) {
            //try {
                //using (var db = new ContextBase(_optionsBuilder)) {
                    //return await db.Operador.Where(exOperador).AsNoTracking().AnyAsync();
                //}
            //}
           // catch (Exception) {

               // return false;
            //}
        //}
    }
}
