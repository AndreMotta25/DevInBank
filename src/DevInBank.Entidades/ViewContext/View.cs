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
            Console.WriteLine("[0] Conta Corrente");
            Console.WriteLine("[1] Conta Poupanca");
            return Pergunta();
        }

        public ModelConta MontarConta()
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

            // DTO
            return new ModelConta(nome, cpf, endereco, rendaMensal, saldo);
        }

        public int Pergunta()
        {
            Console.WriteLine("Qual opção voce deseja ?");
            return int.Parse(Console.ReadLine());
        }
    }
}