using DevInBank.Entidades.AgenciaContext;
using DevInBank.Entidades.InvestimentosContext;
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
            return Pergunta(1);
        }

        public int EscolhaTipoConta()
        {
            Console.Clear();
            Console.WriteLine("======= Painel =======");
            Console.WriteLine("[0] Conta Corrente");
            Console.WriteLine("[1] Conta Poupanca");
            Console.WriteLine("[2] Conta Investimento");
            Console.WriteLine("======================");
            return Pergunta(2);
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

        public int Pergunta(int limite)
        {
            int indiceEscolhido = 0;
            while (true)
            {
                Console.WriteLine("Qual opção voce deseja ?");
                indiceEscolhido = int.Parse(Console.ReadLine());
                if (indiceEscolhido >= 0 && indiceEscolhido <= limite)
                    break;
                Console.Clear();
                Console.WriteLine("Lamento resposta errada");
            }

            return indiceEscolhido;
        }

        // Alterar depois o loop
        public Agencia EscolheAgencia(List<Agencia> agencias)
        {

            Console.Clear();
            Console.WriteLine("Agora chegamos no passo mais importante, Qual e a agencia que voce deseja ? ");

            int indexEscolhido = 0;

            while (true)
            {
                var indice = 0;

                foreach (var agencia in agencias)
                {
                    Console.WriteLine($"[{indice}] {agencia.Name}");
                    indice++;
                }

                indexEscolhido = Pergunta(2);
                if (indexEscolhido <= (agencias.Count - 1))
                    break;

                Console.Clear();
                Console.WriteLine("Lamento, Mas a opcao escolhida esta errada");
            }

            Agencia agenciaEscolhida = agencias[indexEscolhido];

            return agenciaEscolhida;
        }

        public ModelSimulacao SimularPoupancaView()
        {
            Console.WriteLine($"Ao criar uma conta poupanca seu dinheiro vai render!, preencha os dados abaixo para saber mais.");

            decimal porcentagemAnual = 0;

            Console.WriteLine($"Por quantos meses voce quer investir ? obs: digite um numero inteiro");
            int meses = int.Parse(Console.ReadLine());

            Console.WriteLine($"Qual e a porcentage anual da poupanca ? ");
            decimal.TryParse(Console.ReadLine().Replace(".", ","), out porcentagemAnual);

            // DTO  
            return new ModelSimulacao(meses, porcentagemAnual);
        }

        public void EscolheInvestimentoView(List<TipoInvestimento> tiposInvestimentos)
        {
            Console.Clear();
            // lista todos os tipos de investimentos 
            for (int i = 0; i < tiposInvestimentos.Count; i++)
            {
                var tipo = tiposInvestimentos[i];
                Console.WriteLine($"[{i}] {tipo.Nome}: {tipo.Porcentagem}% ao ano. => " +
                    $"Tempo mínimo de aplicação: {tipo.TempoMinimo} meses");
            }

            // Pergunta pro usuario qual é o tipo de investimento que ele deseja fazer
            int indiceDoElementoEscolhido = Pergunta(2);
            var EscolhaInvestimento = tiposInvestimentos[indiceDoElementoEscolhido];

            SimularInvestimentoEscolhidoView(EscolhaInvestimento);

        }
        public void SimularInvestimentoEscolhidoView(TipoInvestimento investimentoEscolhido)
        {
            Console.Clear();

            Console.WriteLine("Quanto você quer investir ?");
            decimal investimento = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Por quantos meses o valor ficará investido ?");
            int meses = int.Parse(Console.ReadLine());

            // validar os meses

        }
        public void ResultadoDaSimulacaoView() { }
    }
}

//um objeto com os dados do tipo do investimento, o tempo, valor...