using DevInBank.Entidades.ContaContext;
using DevInBank.Entidades.TransferenciaContext;
using DevInBank.Entidades.ViewContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInBank.Entidades.AgenciaContext;
using DevInBank.Entidades.InvestimentosContext;

namespace DevInBank.Entidades.AppContext
{
    public class App
    {
        public List<Agencia> Agencias { get; set; }
        public App()
        {
            Transferencias = new List<Transferencia>();
            ContasCorrente = new List<ContaCorrente>();
            ContasPoupanca = new List<ContaPoupanca>();
            ContasInvestimentos = new List<ContaInvestimento>();
            Agencias = new List<Agencia>() {
                new Agencia("Florianópolis","001"),
                new Agencia("São Jose","002"),
                new Agencia("Biguaçu","003")
            };
            Contas = new List<ContaBase>();
            TiposDeInvestimentos = new List<TipoInvestimento>()
            {
                new TipoInvestimento("LCI",5.2M,6),
                new TipoInvestimento("LCA",9,12),
                new TipoInvestimento("CDB",10,36)
            };
            Tempo = DateTime.Now;
            //Console.WriteLine((DateTime.Now.AddDays(5) - DateTime.Now).Days + "Dias");
            //Console.WriteLine((DateTime.Now.AddMonths(6) - DateTime.Now).Days + " dias");
                
        }

        public void CriarConta(ContaPoupanca conta)
        {
            Console.WriteLine("poupanca em produção");
            Contas.Add(conta);
        }
        public void CriarConta(ContaInvestimento conta)
        {
            Console.WriteLine("investimento em produção");
            Contas.Add(conta);
        }
        public void CriarConta(ContaCorrente conta)
        {
            var contaAchada = ContasCorrente.FirstOrDefault(contaSalva => contaSalva.Cpf == conta.Cpf);
            if (contaAchada != null)
                throw new Exception("Uma conta vinculada a este cpf ja existe em nossa base de dados");

            conta.ControladorTransferencia(Transferencias);

            ContasCorrente.Add(conta);
            conta.InformarDados();

            Console.WriteLine("Conta adicionada");
            Contas.Add(conta);
        }

        public int PassarTempo(int meses) {
            var dias = (DateTime.Now.AddMonths(meses) - DateTime.Now).Days; 
            return dias;
        } 



        public List<Transferencia> Transferencias { get; private set; }
        public List<ContaCorrente> ContasCorrente { get; private set; }
        public List<ContaPoupanca> ContasPoupanca { get; private set; }
        public List<ContaInvestimento> ContasInvestimentos { get; private set; }
        public List<TipoInvestimento> TiposDeInvestimentos { get; private set; }
        public List<ContaBase> Contas { get; set; }
        public DateTime TempoSimulado {get;set;}
        public DateTime Tempo {get;set;}    

    }
}


/*
    =============== Alteracoes ================
    1 - Pegar o objeto conta por meio de uma conta
    2 - Modificar o metodo da camada de view onde se escolhe a agencia
*/