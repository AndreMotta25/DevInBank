using DevInBank.Entidades.TransferenciaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInBank.Entidades.AgenciaContext;

namespace DevInBank.Entidades.ContaContext
{
    public class ContaPoupanca : ContaBase
    {
        public ContaPoupanca(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldo, Agencia agencia) :
            base(nome, cpf, endereco, rendaMensal, saldo, agencia )
        {
        }

        public void SimulacaoDeInvestimento(decimal valor, DateTime tempo) {}
    }
}
