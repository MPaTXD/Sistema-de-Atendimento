using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites {
    public class Endereco {
        [Key]
        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Numero_Casa { get; set; }

        [ForeignKey("Estado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        [ForeignKey("Formulario")]
        public int FormularioId { get; set; }
        public Formulario Formulario { get; set; }
    }
}
