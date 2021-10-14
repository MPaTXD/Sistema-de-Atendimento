using Entites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entites.Notifys {
    public class OrdemNotify 
    {
        public OrdemNotify() 
        {
            Notifys = new List<OrdemNotify>();
        }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<OrdemNotify> Notifys;

        public bool ValidarTituloDaOrdem(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Titulo da Ordem não informado!",
                });
                return false;
            }
            return true;
        }

        public bool ValidarDescricaoDaOrdem(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Descrição da Ordem não informada!"
                });
                return false;
            }
            return true;
        }

        public bool ValidarAtendimentoDaOrdem(int atendimento)
        {
            var atendimentoEncontrado = 0;
            foreach (int item in Enum.GetValues(typeof(Atendimentos)))
            {
                if (item == atendimento)
                {
                    atendimentoEncontrado++;
                    break;
                } 
            }
            if (atendimentoEncontrado == 0)
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Atendimento da Ordem Inválido!"
                });
                return false;
            }
            return true;
        }

        public bool ValidarSolicitanteDaOrdem(int valor)
        {
            var solicitanteEncontrado = 0;
            foreach (int item in Enum.GetValues(typeof(Solicitantes)))
            {
                if (item == valor)
                {
                    solicitanteEncontrado++;
                    break;
                }
            }
            if (solicitanteEncontrado == 0)
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Solicitante da Ordem Inválido!"
                });
                return false;
            }
            return true;
        }

        public bool ValidarStatusDaOrdem(int valor)
        {
            var statusEncontrado = 0;
            foreach (int item in Enum.GetValues(typeof(StatusDaOrdem)))
            {
                if (item == valor)
                {
                    statusEncontrado++;
                    break;
                }
            }
            if (statusEncontrado == 0)
            {
                Notifys.Add(new OrdemNotify
                {
                    Mensagem = "Status da Ordem Inválido!"
                });
                return false;
            }
            return true;
        }
    }
}
