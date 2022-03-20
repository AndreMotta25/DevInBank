using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.ContaContext
{
    public class GeradorConta
    {
        public List<string> NumerosConta { get; private set; }
        public Random RandomNums;

        public GeradorConta()
        {
            NumerosConta = new List<string>();
            RandomNums = new Random();
        }

        public string GerarNumeros()
        {
            for (int i = 0; i <= 6; i++)
            {
                NumerosConta.Add($"{RandomNums.Next(10)}");
                if (i == 6)
                {
                    NumerosConta.Add("-");
                    NumerosConta.Add($"{RandomNums.Next(10)}");
                }
            }
            var numeroContaString = String.Join("", NumerosConta);
            return numeroContaString;

        }

    }
}
