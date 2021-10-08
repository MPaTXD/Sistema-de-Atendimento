using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
    public class ServiceOperador : IServiceOperador {

        private readonly IOperador _IOperador;

        public ServiceOperador(IOperador IOperador) {
            _IOperador = IOperador;
        }
        public ServiceOperador() {

        }

        public async Task AddOperador(Operador operador) {
            if (ValidarCamposInput(operador)) {
                var tipoOperador = (int)operador.Atendimento;
                var matricula = GerarMatricula(tipoOperador);
                var verificarMatricula = operador.ValidateInputMatricula(matricula, "Matricula_Operador");
                if (verificarMatricula)
                {
                    operador.Matricula_Operador = matricula;
                    await _IOperador.Add(operador);
                }
            }
        }

        public async Task UpdateOperador(Operador operador) {
            if (ValidarCamposInput(operador)) {
                var verificarOperador = await OperadorId(operador.IdOperador);
                if (operador.Atendimento != verificarOperador.Atendimento) {
                    var newTipo = (int)operador.Atendimento;
                    string matricula = $"{verificarOperador.Matricula_Operador}";
                    StringBuilder newMatricula = new StringBuilder(matricula);
                    newMatricula.Remove(0,1);
                    newMatricula.Insert(0, $"{newTipo}");
                    operador.Matricula_Operador = VerificarMatricula(newMatricula.ToString());
                }
                await _IOperador.Update(operador);
            }
        }

        public bool ValidarCamposInput(Operador operador) {
            var tipo = (int)operador.Atendimento;
            var validarFormatoNome = operador.ValidateName(operador.Nome_Operador, "Nome_Operador");
            var validarTipoOperador = operador.ValidateInputTipoOperador(tipo, "Tipo");
            if (validarFormatoNome && validarTipoOperador) {
                return true;
            }
            return false;
        }
        
        public int VerificarMatricula(string matricula)
        {
            var intMatricula = int.Parse(matricula);
            var verificar = OperadorMatricula(intMatricula);
            if (verificar != null)
            {
                intMatricula++;
            }
            return intMatricula;
        }


        public int GerarMatricula(int tipo) {
            Random r = new Random();
            var dataCadastro = GerarDate().ToString("yyyy");
            string[] formateDate = dataCadastro.Split('/');
            string matricula = $"{tipo}{formateDate[0]}{r.Next(1,100)}";
            var intMatricula = VerificarMatricula(matricula);
            return intMatricula;
        }

        public DateTime GerarDate() {
            var date = DateTime.Now;
            return date;
        }

        public async Task<bool> OperadorMatricula(int matricula)
        {
            return await _IOperador.OperadorMatricula(o => o.Matricula_Operador == matricula);
        }

        public async Task<Operador> OperadorId(int Id)
        {
            return await _IOperador.OperadorId(o => o.IdOperador == Id);
        }
    }
}
