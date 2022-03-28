using DevInBank.Entidades.AgenciaContext;
using DevInBank.Entidades.ContaContext;
using DevInBank.Entidades.InvestimentosContext;
using DevInBank.Entidades.ModelsContext;
using DevInBank.Entidades.AppContext;

namespace DevInBank.Entidades.ViewContext
{

    public static class View
    {

        public static int Menu(App app)
        {
            Console.Clear();
            Console.WriteLine($"======= Painel =======          Data {app.Tempo}");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("[1] Criar Conta");
            Console.WriteLine("[2] Portal do Cliente");
            Console.WriteLine("[3] Listar Contas");
            Console.WriteLine("[4] Listar Contas com saldo negativo");
            Console.WriteLine("[5] Transacoes");
            Console.WriteLine("[6] Total investido");
            Console.WriteLine("======================");
            return Pergunta(7, "Qual opção você deseja ?");
        }
        public static int EscolhaTipoConta()
        {
            Console.Clear();
            Console.WriteLine("======= Painel =======");
            Console.WriteLine("[0] Conta Corrente");
            Console.WriteLine("[1] Conta Poupanca");
            Console.WriteLine("[2] Conta Investimento");
            Console.WriteLine("======================");
            return Pergunta(2, "Qual opção você deseja ?");
        }

        public static int ListarContas()
        {
            Console.WriteLine("[0] Conta Corrente");
            Console.WriteLine("[1] Conta Poupanca");
            Console.WriteLine("[2] Conta Investimento");
            return Pergunta(2, "Qual opção você deseja listar ?");
        }

        public static ModelConta MontarConta(List<Agencia> agencias)
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

        public static int Pergunta(int limite, string mensagem)
        {
            int indiceEscolhido = 0;
            while (true)
            {
                Console.WriteLine($"{mensagem}");
                indiceEscolhido = int.Parse(Console.ReadLine());
                if (indiceEscolhido >= 0 && indiceEscolhido <= limite)
                    break;
                Console.Clear();
                Console.WriteLine("Lamento resposta errada");
            }

            return indiceEscolhido;
        }

        // Alterar depois o loop
        public static Agencia EscolheAgencia(List<Agencia> agencias)
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

                indexEscolhido = Pergunta(2, "Qual opção você deseja ?");
                if (indexEscolhido <= (agencias.Count - 1))
                    break;

                Console.Clear();
                Console.WriteLine("Lamento, Mas a opcao escolhida esta errada");
            }

            Agencia agenciaEscolhida = agencias[indexEscolhido];

            return agenciaEscolhida;
        }

        public static ModelSimulacao SimularPoupancaView()
        {
            Console.WriteLine($"Ao criar uma conta poupanca seu dinheiro vai render!, preencha os dados abaixo para saber mais.");

            decimal porcentagemAnual = 0;

            Console.WriteLine($"Por quantos meses voce quer investir ? obs: digite um numero inteiro");
            int meses = int.Parse(Console.ReadLine());

            Console.WriteLine($"Qual e a porcentage anual da poupanca ? ");
            decimal.TryParse(Console.ReadLine()?.Replace(".", ","), out porcentagemAnual);

            // DTO  
            return new ModelSimulacao(meses, porcentagemAnual);
        }

        public static ModelInvestimento EscolheInvestimentoView(List<TipoInvestimento> tiposInvestimentos)
        {
            Console.Clear();
            Console.WriteLine("Estas são as opçoes de investimentos para você");
            // lista todos os tipos de investimentos 
            for (int i = 0; i < tiposInvestimentos.Count; i++)
            {
                var tipo = tiposInvestimentos[i];
                Console.WriteLine($"[{i}] {tipo.Nome}: {tipo.Porcentagem}% ao ano. => " +
                    $"Tempo mínimo de aplicação: {tipo.TempoMinimo} meses");
            }

            // Pergunta pro usuario qual é o tipo de investimento que ele deseja fazer
            int indiceDoElementoEscolhido = Pergunta(2, "Qual opção você deseja ?");
            var EscolhaInvestimento = tiposInvestimentos[indiceDoElementoEscolhido];

            return SimularInvestimentoEscolhidoView(EscolhaInvestimento);

        }
        public static ModelInvestimento SimularInvestimentoEscolhidoView(TipoInvestimento investimentoEscolhido)
        {
            Console.Clear();

            Console.WriteLine("Quanto você quer investir ?");
            decimal investimento = Convert.ToDecimal(Console.ReadLine());
            int meses = 0;
            while (true)
            {
                Console.WriteLine("Por quantos meses o valor ficará investido ?");
                meses = int.Parse(Console.ReadLine());

                if (meses >= investimentoEscolhido.TempoMinimo)
                    break;
                Console.WriteLine($"Lamento o mes tem que ser maior que  {investimentoEscolhido.TempoMinimo}");
            }
            Console.Clear();

            return new ModelInvestimento(investimentoEscolhido, meses, investimento);

        }
        public static void ResultadoDaSimulacaoView(string resposta)
        {
            Console.WriteLine(resposta);
        }

        public static int DecisaoInvestimentoView()
        {
            Console.WriteLine("[0] => Sim");
            Console.WriteLine("[1] => Não");
            Console.WriteLine("[2] => Voltar");
            Console.WriteLine();
            return Pergunta(2, "Deseja fazer o investimento ?");
        }
        public static void Apagar_E_Esperar_E_MostrarDadosView(ContaBase conta)
        {
            conta.InformarDados();
            Console.WriteLine("Pressione qualquer tecla para voltar para o menu");
            Console.ReadKey();
            Console.Clear();
        }

        public static int InformarcoesDeClientesView(string Mensagem)
        {
            Console.WriteLine($"{Mensagem}");
            return int.Parse(Console.ReadLine());
        }

        // esse metodo é meio inutil já que o metodo acima faz quase a mesma coisa, aqui eu quebro uma regra
        public static ContaBase ContaClienteView(App app, string Mensagem)
        {
            int nConta = InformarcoesDeClientesView(Mensagem);

            var contaTipo = app.Contas.FirstOrDefault(x => x.Conta == nConta);
            if (contaTipo == null)
                throw new Exception("Cliente não achado");
            return contaTipo;
        }

        public static int PortalDoCliente(ContaBase conta)
        {

            Console.WriteLine($"======= Painel ======= {conta.Nome}");
            Console.WriteLine("[0] Saque");
            Console.WriteLine("[1] Deposito");
            Console.WriteLine("[2] Mostrar Saldo");
            Console.WriteLine("[3] Extrato");
            Console.WriteLine("[4] Alterar Dados");
            Console.WriteLine("[5] Transferir ");
            Console.WriteLine($"{(conta is ContaInvestimento ? "[6] Investir" : "")}");

            int numerosPossiveis = (conta is ContaInvestimento ? 7 : 6);
            return Pergunta(numerosPossiveis, "O que você  deseja fazer ?");

        }
    }
}

//um objeto com os dados do tipo do investimento, o tempo, valor...