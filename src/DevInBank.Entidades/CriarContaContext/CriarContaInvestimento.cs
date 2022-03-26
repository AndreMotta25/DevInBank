using DevInBank.Entidades.AppContext;
using DevInBank.Entidades.ContaContext;
using DevInBank.Entidades.ViewContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.CriarContaContext
{
    public class CriarContaInvestimento : CriarContaBase
    {
        public CriarContaInvestimento(ContaInvestimento conta, App aplication) : base(conta, aplication)
        {
        }
        public override void CriarConta()
        {
            Conta.ControladorTransferencia(Application.Transferencias);

            Console.WriteLine("Conta Criada");

            View.Apagar_E_Esperar_E_MostrarDadosView(Conta);

            Application.TotalInvestido += (Conta as ContaInvestimento).CapitalInvestido;

        }
    }
}
