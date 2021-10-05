using Entites.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configs {
    public class ContextBase : DbContext {

        public ContextBase() {
        }
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) {
        }

        public DbSet<Operador> Operador { get; set; }
        public DbSet<Formulario> Formulario { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(StringConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }

        private string StringConnection() {
            string strcon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DESAFIO_WTF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return strcon;
        }
    }
}
