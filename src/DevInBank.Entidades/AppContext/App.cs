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
        public App()
        {
            Transferencias = new List<Transferencia>();
            //ContasCorrente = new List<ContaCorrente>();
            //ContasPoupanca = new List<ContaPoupanca>();
            //ContasInvestimentos = new List<ContaInvestimento>();
            Agencias = new List<Agencia>() {
                new Agencia("Florianópolis","001"),
                new Agencia("São Jose","002"),
                new Agencia("Biguaçu","003")
            };
            Contas = new List<ContaBase>();
            TiposDeInvestimentos = new List<TipoInvestimento>()
            {
                new TipoInvestimento("LCI",8M,6),
                new TipoInvestimento("LCA",9M,12),
                new TipoInvestimento("CDB",10M,36)
            };
            Tempo = DateTime.Now.ToShortDateString();
            // DicionarioContasDiversas = new Dictionary<int, dynamic>()
            // {
            //     { 0,ContasCorrente},
            //     { 1,ContasPoupanca},
            //     { 2,ContasInvestimentos},
            // };
            TotalInvestido = 0;
        }


        // public void CriarConta(ContaPoupanca conta)
        // {

        //     conta.ControladorTransferencia(Transferencias);

        //     Console.WriteLine("Conta Criada");

        //     Contas.Add(conta);
        //     ContasPoupanca.Add(conta);

        //     View.Apagar_E_Esperar_E_MostrarDadosView(conta);
        // }
        public void CriarConta(ContaInvestimento conta)
        {
            Console.Clear();
            VerificarConta(conta);
            string mensagemSucesso = (conta.CapitalInvestido > 0 ? " Dinheiro investido com sucesso" : " Não houve investimento");
            Console.WriteLine("Conta criada." + mensagemSucesso);

            conta.ControladorTransferencia(Transferencias);

            //ContasInvestimentos.Add(conta);
            Contas.Add(conta);

            View.Apagar_E_Esperar_E_MostrarDadosView(conta);

            TotalInvestido += conta.CapitalInvestido;
        }
        // public void CriarConta(ContaCorrente conta)
        // {
        //     conta.ControladorTransferencia(Transferencias);

        //     Console.WriteLine("Conta Criada");

        //     Contas.Add(conta);
        //     ContasCorrente.Add(conta);

        //     View.Apagar_E_Esperar_E_MostrarDadosView(conta);
        // }

        public void SalvarConta(ContaBase conta){
            
            Console.Clear();
            VerificarConta(conta);

            Console.WriteLine("Conta Criada");

            conta.ControladorTransferencia(Transferencias);

            Contas.Add(conta);

            View.Apagar_E_Esperar_E_MostrarDadosView(conta);         
        }    

        public int PassarTempo(int meses)
        {
            var dias = (DateTime.Now.AddMonths(meses) - DateTime.Now).Days;
            return dias;
        }

        public void VerificarConta(ContaBase conta)
        {
            var contaAchada = Contas.FirstOrDefault(contaSalva => contaSalva.Cpf == conta.Cpf);
            if (contaAchada != null)
                throw new Exception("Uma conta vinculada a este cpf ja existe em nossa base de dados");
        }


        public List<Transferencia> Transferencias { get; private set; }
        //public List<ContaCorrente> ContasCorrente { get; private set; }
        //public List<ContaPoupanca> ContasPoupanca { get; private set; }
        //public List<ContaInvestimento> ContasInvestimentos { get; private set; }
        public List<TipoInvestimento> TiposDeInvestimentos { get; private set; }
        public List<ContaBase> Contas { get; private set; }
        //public DateTime TempoSimulado { get; set; }
        public string Tempo { get; private set; }
        //public Dictionary<int, dynamic> DicionarioContasDiversas { get; private set; }
        public decimal TotalInvestido { get; private set; }
        public List<Agencia> Agencias { get; set; }

    }
}


/*
    =============== Alteracoes ================
    2 - Modificar o metodo da camada de view onde se escolhe a agencia
*/