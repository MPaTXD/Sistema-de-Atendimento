using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entites.Notifys {
    public class OrdemNotify {
        public OrdemNotify() {
            Notifys = new List<OrdemNotify>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<OrdemNotify> Notifys;

        public bool ValidateDate(string valor, string nomePropriedade) {
            if (!DateTime.TryParse(valor, out DateTime date) || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notifys.Add(new OrdemNotify {
                    Mensagem = "Ocorreu um erro ao gerar a Data!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidateInputString(string valor, string nomePropriedade) {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notifys.Add(new OrdemNotify {
                    Mensagem = "Campo não informado!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
        
        public bool ValidateMailer(string valor, string nomePropriedade) {
            string formatoMailer = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (Regex.IsMatch(valor, formatoMailer)) {
                return true;
            }
            Notifys.Add(new OrdemNotify {
                Mensagem = "E-mail Inválido!",
                NomePropriedade = nomePropriedade
            });
            return false;
        }

        public bool ValidateInputAreaAtendimento(int valor, string nomePropriedade)
        {
            if (valor == 0 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Atendimento Obrigatório!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            else
            if (valor > 5)
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Atendimento Inválido!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidateInputStatusOrdem(int valor, string nomePropriedade)
        {
            if (valor == 0 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Status Obrigátorio!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            else
            if (valor > 2)
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Status Inválido!",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

    }
}
