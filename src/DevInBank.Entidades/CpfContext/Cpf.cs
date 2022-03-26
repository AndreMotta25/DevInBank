using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.CpfContext
{
    public class Cpf
    {
        private List<int> _pesos = new List<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private List<int> NumerosCpf { get; set; }
        public string? CpfOriginal { get; private set; }
        private string? CpfCopia { get; set; }

        public Cpf(string cpf)
        {
            InserirCpf(cpf);
            NumerosCpf = new List<int>();
            CpfToList();
            ValidarCpf();
        }

        public string? ValidarCpf()
        {
            if (NumerosCpf.Count < 11)
            {

                int soma = 0;
                for (int indice = 0; indice < _pesos.Count; indice++)
                {
                    soma += NumerosCpf[indice] * _pesos[indice];
                }
                var result = 11 - (soma % 11);

                NumerosCpf.Add(Verifica_E_RetornaDigito(result));
                ValidarCpf();
            }

            var cpfValidado = String.Join("", NumerosCpf);
            if (!(cpfValidado == CpfCopia))
                throw new Exception("OPA!, temos um erro. O cpf nao e valido");

            return CpfOriginal;
        }

        private int Verifica_E_RetornaDigito(int digito)
        {
            _pesos.Insert(0, 11);

            if (digito > 9)
                return 0;
            return digito;
        }

        private string? LimparCpf()
        {
            var cpfSemPontos = CpfOriginal?.Replace(".", "#").Replace("-", "#");
            var cpfParcialmenteLimpo = cpfSemPontos?.Split("#").ToList<string>();

            // vamos ter uma copia do cpf original antes de ser validado
            CpfCopia = String.Join("", cpfParcialmenteLimpo);

            // Tem que remover os numeros apos o traco(-) para formula funcionar
            cpfParcialmenteLimpo.RemoveAt(3);

            var cpfLimpo = String.Join("", cpfParcialmenteLimpo);
            return cpfLimpo;

        }

        // Converte os numeros do cpf que eram string para inteiros e insere na Lista NumerosCpf 
        private void CpfToList()
        {
            var cpfFiltrado = LimparCpf();
            //converte a string para um array em char
            foreach (var cpf in cpfFiltrado.ToArray())
            {
                // transformar os numeros que estao em char para int 
                NumerosCpf.Add(int.Parse(cpf.ToString()));
            }

        }

        private void InserirCpf(string cpf)
        {
            if (!(cpf.Length == 14))
                throw new Exception("OPA!, temos um erro. O cpf deve estar no formato ###.###.###-##");

            CpfOriginal = cpf;
        }
    }
}
