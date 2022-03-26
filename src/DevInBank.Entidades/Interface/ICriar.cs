using DevInBank.Entidades.AppContext;
using DevInBank.Entidades.ContaContext;
using DevInBank.Entidades.TransferenciaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.Interface
{

    public interface ICriar
    {
        public ContaBase Conta { get; set; }
        public App Application { get; set; }

        abstract void CriarConta();

    }
}
