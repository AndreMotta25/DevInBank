using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInBank.Entidades.EnumAgencia;
using DevInBank.Entidades.CpfContext;
using DevInBank.Entidades.TransacoesContext;
using DevInBank.Entidades.CategoriaContext;
using DevInBank.Entidades.EnumCategoria;

namespace DevInBank.Entidades.ContaContext
{
    public abstract class ContaBase
    {
        #region Propriedades
        // string
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        private Cpf ValidarCpf { get; set; }
        public string Endereco { get; private set; }

        // decimal
        public decimal RendaMensal { get; private set; }
        public decimal SaldoConta { get; protected set; }
        // Enum
        public EAgencia Agencia { get; private set; }
        public string Conta { get; private set; }

        public List<Transacao> Transacoes { get; set; }

        #endregion

        public ContaBase(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldo)
        {
            Nome = nome;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            SaldoConta = saldo;
            Transacoes = new List<Transacao>();
            Agencia = (EAgencia)new Random().Next(3);
            Conta = new GeradorConta().GerarNumeros();
            ValidarCpf = new Cpf(cpf);
            Cpf = ValidarCpf.ValidarCpf();
        }


        public virtual void Saque(decimal valor)
        {
            if (valor <= SaldoConta)
            {
                SaldoConta -= valor;
                
                Categoria categoria = new Categoria("Saque",ECategoria.Despesa);
                Transacoes.Add(new Transacao(valor,categoria, DateTime.Now.AddDays(-1)));

                Console.WriteLine("Saque efetuado");
            }
            else
                Console.WriteLine("Voce nao possui valor o suficiente para fazer esse saque!");
            return;
        }

        public virtual string Saldo()
        {

            return $"Seu saldo é: {SaldoConta:N2}";
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor > 0){
                SaldoConta += valor;
                Categoria categoria = new Categoria("Deposito",ECategoria.Receita);
                Transacoes.Add(new Transacao(valor,categoria, DateTime.Now.AddDays(-1)));
            }    
        }
        
        public virtual void Extrato() {
            Console.WriteLine("================= Extrato ==================");
            foreach(Transacao tr in Transacoes) {
                Console.WriteLine($"{tr.Categoria.TipoCategoria} => R${tr.Valor:N2} Data: {tr.DataTransacao}");
            }
        }
        
    }
}
