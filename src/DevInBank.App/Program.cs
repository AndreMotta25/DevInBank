using DevInBank.Entidades.AppContext;
using DevInBank.Entidades.ViewContext;
using DevInBank.Entidades.ContaContext;
using DevInBank.Entidades.ModelsContext;

var app = new App();
View visualizacao = new View();

while (true)
{
    try
    {
        int opt = visualizacao.Menu();

        if (opt == 0)
            break;

        else if (opt == 1)
        {
            opt = visualizacao.EscolhaTipoConta();
            var dadosConta = visualizacao.MontarConta(app.Agencias);

            // gera o numero da conta, semelhante a um id que vai sempre se incrementando
            int numeroConta = app.Contas.Count + 1;

            Console.Clear();

            if (opt == 0)
            {
                app.CriarConta(new ContaCorrente(dadosConta.Nome,
                                                 dadosConta.Cpf,
                                                 dadosConta.Endereco,
                                                 dadosConta.RendaMensal,
                                                 dadosConta.SaldoConta,
                                                 dadosConta.Agencia,
                                                 numeroConta));
            }
            else if (opt == 1)
            {
                var conta = new ContaPoupanca(dadosConta.Nome,
                                                 dadosConta.Cpf,
                                                 dadosConta.Endereco,
                                                 dadosConta.RendaMensal,
                                                 dadosConta.SaldoConta,
                                                 dadosConta.Agencia,
                                                 numeroConta);

                var simulacaoRendimento = visualizacao.SimularPoupancaView();

                conta.SimulacaoDeInvestimento(simulacaoRendimento.Meses, simulacaoRendimento.RentabilidadeAnual);

                app.CriarConta(conta);
            }
            else if (opt == 2)
            {
                var conta = new ContaInvestimento(dadosConta.Nome,
                                                 dadosConta.Cpf,
                                                 dadosConta.Endereco,
                                                 dadosConta.RendaMensal,
                                                 dadosConta.SaldoConta,
                                                 dadosConta.Agencia,
                                                 numeroConta);
                app.VerificarConta(conta);
                while (true)
                {
                    ModelInvestimento escolhaInvestimento = visualizacao.EscolheInvestimentoView(app.TiposDeInvestimentos);
                    // transformar meses para dias
                    int mesesParaDias = app.PassarTempo(escolhaInvestimento.TotalDeMeses);
                    var resposta = conta.InvestimentoSolicitado(escolhaInvestimento, mesesParaDias);
                    var r = visualizacao.ResultadoDaSimulacaoView(resposta);

                    if (r == 0)
                    {
                        conta.FazerInvestimento(escolhaInvestimento, mesesParaDias);
                        break;
                    }
                    else if (r == 1)
                        break;
                    else if (r == 2)
                        continue;
                }
                app.CriarConta(conta);
            }

        }
        else if (opt == 3)
        {
            if (app.Contas.Count > 0)
            {
                foreach (ContaBase conta in app.Contas)
                {
                    conta.InformarDados();
                }
                return;
            }
            throw new Exception("Não temos contas ainda!");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Pressione qualquer tecla para voltar para o inicio");
        Console.ReadKey();
        Console.Clear();
    }
}