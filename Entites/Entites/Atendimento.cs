using Entites.Enums;
using Entites.Notifys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites {
    public class Atendimento : AtendimentoNotify {
        [Key]
        public int IdAtendimento { get; set; }
        public int Protocolo { get; set; }
        public StatusDoAtendimento Status { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public DateTime DataDeConclusao { get; set; }

        [ForeignKey("Formulario")]
        public int OrdemId { get; set; }
        public Ordem Formulario { get; set; }

        [ForeignKey("Operador")]
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
