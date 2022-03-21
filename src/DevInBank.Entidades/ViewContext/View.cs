using DevInBank.Entidades.AgenciaContext;
using DevInBank.Entidades.ModelsContext;

namespace DevInBank.Entidades.ViewContext
{

    public class View
    {

        public int Menu()
        {
            Console.WriteLine("======= Painel =======");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("[1] Criar Conta");
            Console.WriteLine("======================");
            return Pergunta();
        }

        public int EscolhaTipoConta()
        {
            Console.Clear();
            Console.WriteLine("[0] Conta Corrente");
            Console.WriteLine("[1] Conta Poupanca");
            return Pergunta();
        }

        public ModelConta MontarConta(List<Agencia> agencias)
        {
            Console.Clear();
            Console.WriteLine("Digite seu nome: ");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite seu cpf, Obs: O cpf deve estar no formato ###.###.###-## ");
            var cpf = Console.ReadLine();

            Console.WriteLine("Digite seu endereco: ");
            var endereco = Console.ReadLine();

            Console.WriteLine("Qual e a sua renda mensal ?");
            var rendaMensal = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Quanto voce quer depositar pela primeira vez ? ");
            var saldo = Convert.ToDecimal(Console.ReadLine());
            
            Agencia agenciaEscolhida = EscolheAgencia(agencias);

            // DTO
            return new ModelConta(nome, cpf, endereco, rendaMensal, saldo, agenciaEscolhida);
        }

        public int Pergunta()
        {
            Console.WriteLine("Qual opção voce deseja ?");
            return int.Parse(Console.ReadLine());
        }

        public Agencia EscolheAgencia(List<Agencia> agencias) {
            
            Console.Clear();
            Console.WriteLine("Agora chegamos no passo mais importante, Qual e a agencia que voce deseja ? ");
            
            int indexEscolhido = 0;
            
            while(true) {
                var indice = 0;
                
                foreach(var agencia in agencias) {
                    Console.WriteLine($"[{indice}] {agencia.Name}");
                    indice++;
                }

                indexEscolhido = Pergunta();
                if (indexEscolhido <= (agencias.Count-1))
                    break;
                
                Console.Clear();    
                Console.WriteLine("Lamento, Mas a opcao escolhida esta errada"); 
            }
                    
            Agencia agenciaEscolhida = agencias[indexEscolhido];

            return agenciaEscolhida;
        } 

        public ModelSimulacao SimularPoupancaView() 
        {
            decimal porcentagemAnual =  0;
            
            Console.WriteLine($"Por quantos meses voce quer investir ? obs: digite um numero inteiro");
            int meses = int.Parse(Console.ReadLine());

            Console.WriteLine($"Qual e a porcentage anual da poupanca ? ");
            decimal.TryParse(Console.ReadLine().Replace(".",","),out porcentagemAnual);

            // DTO  
            return  new ModelSimulacao(meses,porcentagemAnual);
        }
    }
}