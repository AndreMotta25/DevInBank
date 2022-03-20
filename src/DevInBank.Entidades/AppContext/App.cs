using DevInBank.Entidades.ContaContext;
using DevInBank.Entidades.TransferenciaContext;
using DevInBank.Entidades.ViewContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.AppContext
{
    public class App
    {
        public App()
        {
            Transferencias = new List<Transferencia>();
            ContasCorrente = new List<ContaCorrente>();
            ContasPoupanca = new List<ContaPoupanca>();
            ContasInvestimentos = new List<ContaInvestimento>();
            //ViewLayer = new View();
        }

        public void CriarConta(ContaPoupanca conta)
        {
            Console.WriteLine("poupanca");
        }
        public void CriarConta(ContaCorrente conta)
        {
            var contaAchada = ContasCorrente.FirstOrDefault(contaSalva => contaSalva.Cpf == conta.Cpf);
            if (contaAchada != null)
                throw new Exception("Uma conta vinculada a este cpf ja existe em nossa base de dados");

            ContasCorrente.Add(conta);
            Console.WriteLine("Os dados da sua conta sao: ");
            Console.WriteLine("Conta adicionada");
        }


        public List<Transferencia> Transferencias { get; private set; }
        public List<ContaCorrente> ContasCorrente { get; private set; }
        public List<ContaPoupanca> ContasPoupanca { get; private set; }
        public List<ContaInvestimento> ContasInvestimentos { get; private set; }
        //public View ViewLayer { get; set; }



    }
}
