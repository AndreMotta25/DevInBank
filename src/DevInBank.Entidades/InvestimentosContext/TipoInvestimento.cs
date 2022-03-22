﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.InvestimentosContext
{
    public class TipoInvestimento
    {
        public TipoInvestimento(string nome, int porcentagem, int tempoMinimo)
        {
            Nome = nome;
            Porcentagem = porcentagem;
            TempoMinimo = tempoMinimo;
        }

        public string Nome { get; private set; }
        public int Porcentagem { get; private set; }
        public int TempoMinimo { get; private set; }

    }
}
