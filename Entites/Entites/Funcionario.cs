using Entites.Enums;
using Entites.Notifys;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites {
    public class Funcionario : FuncionarioNotify {
        public int IdFuncionario { get; set; }
        public long Matricula { get; set; }
        public string Nome { get; set; }
        public Atendimentos Atendimento { get; set; }
        //public virtual ICollection<Atendimento> atendimentos { get; set; }
    }
}
