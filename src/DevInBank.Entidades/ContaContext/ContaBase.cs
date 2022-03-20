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
using DevInBank.Entidades.TransferenciaContext;

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

        // teste 
        public List<Transferencia> Transferencias { get; set; }
        public Guid Id { get; private set; }




        #endregion

        public ContaBase(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldo, List<Transferencia> transferencias)
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
            Transferencias = transferencias;
            Id = Guid.NewGuid();
        }


        public virtual void Saque(decimal valor)
        {
            if (valor <= SaldoConta)
            {
                SaldoConta -= valor;

                Console.WriteLine("Saque efetuado");
                CriarTransacao("Saque", valor, ECategoria.Despesa);
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
            if (valor > 0)
            {
                SaldoConta += valor;
                CriarTransacao("Deposito", valor, ECategoria.Receita);
            }
        }

        public virtual void Extrato()
        {
            Console.WriteLine("================= Extrato ==================");
            foreach (Transacao tr in Transacoes)
            {
                Console.WriteLine($"{tr.Categoria.Nome} => R${tr.Valor:N2} Data: {tr.DataTransacao}");
            }
        }

        // talvez eu tenha que modificar algumas coisas aqui ainda(tira o id)
        public virtual void Transferencia(ContaBase contaDestino, decimal valor)
        {
            if (valor <= SaldoConta && !(Id == contaDestino.Id))
            {
                SaldoConta -= valor;
                contaDestino.Depositar(valor);
                Console.WriteLine($"Transferindo dinheiro para {contaDestino.Nome}");

                Transferencia transferencia = new Transferencia(this, contaDestino, DateTime.Now, valor);
                Transferencias.Add(transferencia);
                CriarTransacao("Transferencia", valor, ECategoria.Despesa);
                return;
            }
            else if (Id == contaDestino.Id && Cpf == contaDestino.Cpf)
                throw new Exception("Nao pode transferir para usuarios de mesma titularidade");

            else
                throw new Exception("Erro na transferencia...");
        }

        public void CriarTransacao(string ctg, decimal valor, ECategoria tipo)
        {

            Categoria categoria = new Categoria(ctg, tipo);
            Transacoes.Add(new Transacao(valor, categoria, DateTime.Now.AddDays(-1)));

        }
    }
}
