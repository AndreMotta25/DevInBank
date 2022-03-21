namespace DevInBank.Entidades.ModelsContext {
    
    public class ModelSimulacao {
        
        public ModelSimulacao(int meses, decimal porcentagem)
        {
            Meses = meses;
            RentabilidadeAnual = porcentagem;
        }

        public int Meses {get; set;}
        public decimal RentabilidadeAnual {get;set;}
    }
}