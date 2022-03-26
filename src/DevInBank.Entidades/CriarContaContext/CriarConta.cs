using DevInBank.Entidades.AppContext;
using DevInBank.Entidades.Interface;
using DevInBank.Entidades.TransferenciaContext;
using DevInBank.Entidades.ViewContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.ContaContext
{
    public abstract class CriarContaBase
    {
        public CriarContaBase(ContaBase conta, App aplication)
        {
            ContaBase Conta = conta;
            Application = aplication;
        }

        public ContaBase Conta { get; set; }
        public App Application { get; set; }

        public abstract void CriarConta();

    }
}
