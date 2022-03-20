using DevInBank.Entidades.ContaContext;

namespace DevInBank.Entidades.TransferenciaContext {


    public class Transferencia {
        
        public Transferencia(ContaBase contaOrigem, ContaBase contaDestino, DateTime data, decimal valor)
        {
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Data = data;
            Valor = valor;
        }

        public ContaBase ContaOrigem { get; private set; }
        public ContaBase ContaDestino { get; private set; }

        public DateTime Data {get;set;}

        public decimal Valor {get;set;}
        
    }
} 