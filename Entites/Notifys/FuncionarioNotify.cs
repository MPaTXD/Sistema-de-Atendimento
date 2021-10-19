using Entites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entites.Notifys {
    public class FuncionarioNotify {

        public FuncionarioNotify() {
            Notifys = new List<FuncionarioNotify>();

        }

        [NotMapped]
        public string Mensagem { get; private set; }

        [NotMapped]
        public List<FuncionarioNotify> Notifys;

      
        public bool ValidarNomeDoFuncionario(string valor) {
            string ValidacaoDoNome = @"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)";
            if (Regex.IsMatch(valor, ValidacaoDoNome)) {
                return true;
            }
            Notifys.Add(new FuncionarioNotify {
                Mensagem = "Nome do funcionário com formato inválido!",
            });
            return false;
        }

        public bool ValidarAtendimentoDoFuncionario(int valor) {
            if (valor == 0) {
                Notifys.Add(new FuncionarioNotify {
                    Mensagem = "Atendimento Obrigatório!",
                });
                return false;
            }else
            if (valor > 7) {
               Notifys.Add(new FuncionarioNotify {
                   Mensagem = "Atendimento não cadastrado no sistema!",
                });
               return false;
            }
            return true;
        }
    }
}
