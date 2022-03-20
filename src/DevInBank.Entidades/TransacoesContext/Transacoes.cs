using DevInBank.Entidades.CategoriaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Entidades.TransacoesContext
{
    public class Transacao
    {
        public Transacao(decimal valor, Categoria categoria, DateTime dataTransacao)
        {
            Categoria = categoria;
            Valor = valor;
            DataTransacao = dataTransacao;
        }

        public Categoria Categoria { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataTransacao { get; private set; }
    }
}
