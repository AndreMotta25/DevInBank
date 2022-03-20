using DevInBank.Entidades.TransferenciaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.ContaContext
{
    public class ContaPoupanca : ContaBase
    {
        public ContaPoupanca(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldo, List<Transferencia> transferencias) :
            base(nome, cpf, endereco, rendaMensal, saldo, transferencias)
        {
        }
    }
}
