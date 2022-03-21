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
        public ContaPoupanca(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldo, Agencia agencia, int conta) :
            base(nome, cpf, endereco, rendaMensal, saldo, agencia, conta )
        {
        }

        public void SimulacaoDeInvestimento(int meses,decimal porcentagemAnual) {      
             decimal porcentagemMensal = ((porcentagemAnual/12) / 100);
             var valor  =  SaldoConta;   
             
             for(int mes = 0; mes < meses; mes++){
                valor += porcentagemMensal * valor;
             }
            
            Console.WriteLine($"{valor:N2}");
        }
    }
}
