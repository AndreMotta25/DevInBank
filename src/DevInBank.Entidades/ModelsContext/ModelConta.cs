﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInBank.Entidades.EnumAgencia;

namespace DevInBank.Entidades.ModelsContext
{
    public class ModelConta
    {
        public ModelConta(string nome, string cpf, string endereco, decimal rendaMensal, decimal saldoConta)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            SaldoConta = saldoConta;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }
        public decimal RendaMensal { get; private set; }
        public decimal SaldoConta { get; protected set; }

    }
}
