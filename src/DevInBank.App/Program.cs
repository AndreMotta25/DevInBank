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
            
            Console.Clear();

            if (opt == 0)
                app.CriarConta(new ContaCorrente(dadosConta.Nome,
                                                 dadosConta.Cpf,
                                                 dadosConta.Endereco,
                                                 dadosConta.RendaMensal,
                                                 dadosConta.SaldoConta,
                                                 dadosConta.Agencia));
            else if (opt == 1)
                app.CriarConta(new ContaPoupanca(dadosConta.Nome,
                                                 dadosConta.Cpf,
                                                 dadosConta.Endereco,
                                                 dadosConta.RendaMensal,
                                                 dadosConta.SaldoConta,
                                                 dadosConta.Agencia));
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