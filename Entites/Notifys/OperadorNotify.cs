using Entites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entites.Notifys {
    public class OperadorNotify {

        public OperadorNotify() {
            Notifys = new List<OperadorNotify>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<OperadorNotify> Notifys;

      
        public bool ValidateName(string valor, string nomePropriedade) {
            string formatoName = @"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)";
            if (Regex.IsMatch(valor, formatoName)) {
                return true;
            }
            Notifys.Add(new OperadorNotify {
                Mensagem = "Nome inválido, verifique se digitou corretamente!",
                NomePropriedade = nomePropriedade
            });
            return false;
        }

        public bool ValidateInputTipoOperador(int valor, string nomePropriedade) {
            if (valor == 0 || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notifys.Add(new OperadorNotify {
                    Mensagem = "Atendimento Obrigatório!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }else
            if (valor > 5) {
                Notifys.Add(new OperadorNotify {
                    Mensagem = "Atendimento não existe!",
                    NomePropriedade = nomePropriedade
                });
               return false;
            }
            return true;
        }

        public bool ValidateInputMatricula(int valor, string nomePropriedade) {
            if (valor == 0 || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notifys.Add(new OperadorNotify {
                    Mensagem = "Ocorreu um erro ao gerar a Matrícula do Operador!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
    }
}
