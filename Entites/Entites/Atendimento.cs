﻿using Entites.Enums;
using Entites.Notifys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites {
    public class Atendimento {
        [Key]
        public int IdAtendimento { get; set; }
        public long Protocolo { get; set; }
        public StatusDoAtendimento Status { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public DateTime DataDeConclusao { get; set; }

        [ForeignKey("Ordem")]
        public int OrdemId { get; set; }
        public Ordem Ordem { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
