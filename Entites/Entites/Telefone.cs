﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites {
    public class Telefone {
        [Key]
        public int IdTelefone { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }

        [ForeignKey("Ordem")]
        public int OrdemId { get; set; }
        public Ordem Ordem { get; set; }
    }
}