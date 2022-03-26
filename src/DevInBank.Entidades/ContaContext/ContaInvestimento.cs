using DevInBank.Entidades.AgenciaContext;
using DevInBank.Entidades.InvestimentosContext;
using DevInBank.Entidades.ModelsContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInBank.Entidades.ViewContext;

namespace DevInBank.Entidades.ContaContext
{
    public class ContaInvestimento : ContaBase
    {
        public ModelInvestimento? Investimento { get; private set; }
        public int Dias { get; private set; }

        public bool DinheiroInvestido { get; private set; }

        public decimal CapitalInvestido { get; private set; }

        public ContaInvestimento(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldo, Agencia agencia, int conta) : base(nome, cpf, endereco, rendaMensal, saldo, agencia, conta)
        {
            DinheiroInvestido = false;
        }

        public void InvestimentoSolicitado(ModelInvestimento investimento, int dias)
        {
            decimal montante = CalcularInvestimento(investimento, dias);

            View.ResultadoDaSimulacaoView($"A {investimento.Tipo.Nome} Renderá {investimento.Tipo.Porcentagem}% resultando num montante de " +
                $"{montante:C2}");
        }

        private decimal CalcularInvestimento(ModelInvestimento investimento, int dias)
        {
            var jurosPorDia = (Math.Pow(1D + ((double)investimento.Tipo.Porcentagem / 100D), 1D / 360D) - 1) * 100;
            var montante = investimento.Capital * Convert.ToDecimal(Math.Pow((1 + (jurosPorDia / 100)), dias));
            return montante;
        }
        public void FazerInvestimento(ModelInvestimento investimento, int dias)
        {
            Investimento = investimento;
            Dias = dias;

            DinheiroInvestido = true;

            InvestirDinheiro(investimento.Capital);
        }

        public void TransferirInvestimentos(decimal valor)
        {
            if (!DinheiroInvestido && DateTime.Now > Investimento?.Data && CapitalInvestido > 0)
            {
                base.Depositar(valor);
                return;
            }
            throw new Exception($"Lamento, mais o seu dinheiro está investido até a data {Investimento?.Data}");

        }
        private void InvestirDinheiro(decimal valor)
        {
            if (valor > 0)
            {
                DinheiroInvestido = false;
                CapitalInvestido = valor;
                return;
            }
            throw new Exception("Lamento mas você não tem dinheiro o suficiente para fazer esse investimento");

        }

        public override void Transferencia(ContaBase contaDestino, decimal valor)
        {
            if (valor <= SaldoConta)
                base.Transferencia(contaDestino, valor);
        }
    }
}
