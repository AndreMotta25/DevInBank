using DevInBank.Entidades.AgenciaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.ContaContext
{
    public class ContaInvestimento : ContaBase
    {
        public ContaInvestimento(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldo, Agencia agencia, int conta) : base(nome, cpf, endereco, rendaMensal, saldo, agencia, conta)
        {
        }

        // passar um modelDados com os dados de investimento
        public void InvestimentoSolicitado(int tipoInvestimento)
        {

        }
    }
}
