﻿using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices {
    public interface IServiceAtendimento {
        Task AddAtendimento(Atendimento atendimento, Ordem ordem, Funcionario funcionario);
        Task<List<Atendimento>> ListarAtendimentos();
        Task<bool> VerificarAtendimentoPeloProtocolo(long protocolo);
    }
}
