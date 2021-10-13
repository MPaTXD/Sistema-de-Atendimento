using Domain.Services;
using Entites.Entites;
using Entites.Enums;
using System;
using Xunit;

namespace TestProject {
    public class TestServiceOperador {
        Funcionario op = new Funcionario();
        ServiceFuncionario operador = new ServiceFuncionario();

        [Fact]
        public void TestGenerateMatricula() {
            var date = operador.GerarDate();
            op.Tipo = Atendimentos.SAC;
            var hj = DateTime.Now;
            Assert.Equal(date.ToString("dd/MM/yyyy"), hj.ToString("dd/MM/yyyy"));
            //var matricula = operador.GerarMatricula(date.ToString("dd/MM/yyyy"),op);
            //Assert.Equal(120210922, matricula);
            
        }

        [Fact]
        public void TestInputsOperador() {
            op.Nome_Operador = "Nome Sobrenome";
            //op.Tipo = TipoOperador.SAC;
            var verificar = operador.ValidarCamposInput(op);
            Assert.True(verificar);
        }
    }
}
