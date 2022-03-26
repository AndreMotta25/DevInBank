using DevInBank.Entidades.CategoriaContext;
using DevInBank.Entidades.InvestimentosContext;

namespace DevInBank.Entidades.TransacoesContext
{
    public class TransacaoInvestimento : Transacao
    {
        public TransacaoInvestimento(decimal valor, Categoria categoria, DateTime dataTransacao, DateTime dataDaRetirada, string tipo) : 
        base(valor,categoria,dataTransacao)
        {
            DataDaRetirada = dataDaRetirada;
            Tipo = tipo;
        }

        public DateTime DataDaRetirada { get; set; }
        public string? Tipo { get; set; }
        
        
        
    }

}