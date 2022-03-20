using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInBank.Entidades.TransacoesContext;
using DevInBank.Entidades.CategoriaContext;
using DevInBank.Entidades.EnumCategoria;

namespace DevInBank.Entidades.ContaContext
{
    public class ContaCorrente : ContaBase
    {
        public decimal LimiteChequeEspecial { get; private set; }
        public ContaCorrente(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldo) :
            base(nome, cpf, endereco, rendaMensal, saldo)
        {
            LimiteChequeEspecial = rendaMensal * 0.10M;
        }


        public override void Saque(decimal valor)
        {
            if (valor <= SaldoConta)
                base.Saque(valor);

            else if (valor <= (SaldoConta + LimiteChequeEspecial))
            {
                var resultadoSaque = (SaldoConta + LimiteChequeEspecial - valor) - LimiteChequeEspecial;
                var chequeEspecial = (SaldoConta + LimiteChequeEspecial) - valor;

                LimiteChequeEspecial = chequeEspecial;
                SaldoConta = resultadoSaque;
                
                Categoria categoria = new Categoria("Saque",ECategoria.Despesa);
                Transacoes.Add(new Transacao(valor,categoria, DateTime.Now.AddDays(-1)));

                Console.WriteLine(SaldoConta);
                Console.WriteLine("Saque efetuado");
                Console.WriteLine("Obs:Voce utilizou um pouco do seu cheque especial");
            }
            else
                base.Saque(valor);

        }

        public override string Saldo()
        {
            return base.Saldo() + $" Cheque especial: {LimiteChequeEspecial:N2}";
        }

        public override void Depositar(decimal valor)
        {
            var newValor = valor;
            if (SaldoConta <= 0 && valor > 0)
                LimiteChequeEspecial += Math.Abs(SaldoConta);
            base.Depositar(newValor);
        }
    }
}
