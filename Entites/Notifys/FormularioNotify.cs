using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entites.Notifys {
    public class FormularioNotify {
        public FormularioNotify() {
            Notifys = new List<FormularioNotify>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<FormularioNotify> Notifys;

        public bool ValidateDate(string valor, string nomePropriedade) {
            if (!DateTime.TryParse(valor, out DateTime date) || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notifys.Add(new FormularioNotify {
                    Mensagem = "Data de Nascimento Inválida ou não Informada!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidateInputString(string valor, string nomePropriedade) {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notifys.Add(new FormularioNotify {
                    Mensagem = "Campo não informado!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidateCpf(string valor, string nomePropriedade) {
            string formatoCPF = @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$";
            if (Regex.IsMatch(valor,formatoCPF)) {
                return true; 
            }
            Notifys.Add(new FormularioNotify {
                Mensagem = "CPF Inválido!",
                NomePropriedade = nomePropriedade
            });
            return false;
        }

        public bool ValidateSexo(string valor, string nomePropriedade) {
            if (valor.Contains('M') || valor.Contains('F')) {
                return true; 
            }
            Notifys.Add(new FormularioNotify {
                Mensagem = "Sexo Inválido!",
                NomePropriedade = nomePropriedade
            });
            return false;
        }

        public bool ValidateMailer(string valor, string nomePropriedade) {
            string formatoMailer = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (Regex.IsMatch(valor, formatoMailer)) {
                return true;
            }
            Notifys.Add(new FormularioNotify {
                Mensagem = "E-mail Inválido!",
                NomePropriedade = nomePropriedade
            });
            return false;
        }

        public bool ValidateCpnj(string valor, string nomePropriedade) {
            string formatoCpnj = @"^((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))*$";
            if (Regex.IsMatch(valor, formatoCpnj)) {
                return true;
            }
            Notifys.Add(new FormularioNotify {
                Mensagem = "CNPJ Inválido!",
                NomePropriedade = nomePropriedade
            });
            return false;
        }
    }
}
