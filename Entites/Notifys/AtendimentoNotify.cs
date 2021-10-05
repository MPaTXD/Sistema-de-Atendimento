using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Notifys {
    public class AtendimentoNotify {

        public AtendimentoNotify() {
            Notifys = new List<AtendimentoNotify>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<AtendimentoNotify> Notifys;

        public bool ValidateDate(string valor, string nomePropriedade) {
            if (DateTime.TryParse(valor, out DateTime date) || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notifys.Add(new AtendimentoNotify {
                    Mensagem = "Ocorreu um erro ao gerar a Data do Atendimento!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidateProtocolo(int valor, string nomePropriedade) {
            if (valor < 0 || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notifys.Add(new AtendimentoNotify {
                    Mensagem = "Ocorreu um erro ao gerar o Protocolo do Atendimento!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
    }
}
