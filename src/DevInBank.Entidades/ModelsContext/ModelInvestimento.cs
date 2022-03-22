using DevInBank.Entidades.InvestimentosContext;

namespace DevInBank.Entidades.ModelsContext {

    public class ModelInvestimento {
        public ModelInvestimento(TipoInvestimento tipo, int totalDeMeses, decimal capital)
        {
            Tipo = tipo;
            TotalDeMeses = totalDeMeses;
            Capital = capital;
        }

        public TipoInvestimento Tipo { get; private set; }

        public int TotalDeMeses {get;set;}
        
        public decimal Capital {get;set;}
        
    }
}