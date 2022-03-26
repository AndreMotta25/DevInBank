﻿using DevInBank.Entidades.AppContext;
using DevInBank.Entidades.ViewContext;
using DevInBank.Entidades.ContaContext;
using DevInBank.Entidades.ModelsContext;
using DevInBank.Entidades.Interface;
using DevInBank.Entidades.CriarContaContext;

var app = new App();

while (true)
{
    try
    {
        int opt = View.Menu(app);

        if (opt == 0)
            break;
        else if (opt == 1)
        {
            opt = View.EscolhaTipoConta();
            var dadosConta = View.MontarConta(app.Agencias);

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

                var simulacaoRendimento = View.SimularPoupancaView();

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

                /*ICriar criadorConta = new CriarContaInvestimento(conta, app);

                app.CriarContaTeste(criadorConta);
*/

                while (true)
                {
                    ModelInvestimento escolhaInvestimento = View.EscolheInvestimentoView(app.TiposDeInvestimentos);
                    // transformar meses para dias
                    int mesesParaDias = app.PassarTempo(escolhaInvestimento.TotalDeMeses);
                    conta.InvestimentoSolicitado(escolhaInvestimento, mesesParaDias);

                    var r = View.DecisaoInvestimentoView();

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
        else if (opt == 2)
        {
            ContaBase conta = View.ContaClienteView(app, "digite o numero da conta");
            int resposta = View.PortalDoCliente(conta);

            if (resposta == 0)
            {
                Console.WriteLine("Quanto você deseja sacar ?");
                conta.Saque(Convert.ToDecimal(Console.ReadLine()));
            }
            else if (resposta == 1)
            {
                Console.WriteLine("Valor do deposito ?");
                conta.Depositar(Convert.ToDecimal(Console.ReadLine()));
            }
            else if (resposta == 2)
            {
                Console.WriteLine(conta.Saldo());

            }
            else if (resposta == 3)
            {
                conta.Extrato();
            }
            else if (resposta == 4)
                // to do 
                Console.WriteLine();

            else if (resposta == 5)
            {
                ContaBase contaDestino = View.ContaClienteView(app, "Digite o numero da conta destino");
                Console.WriteLine($"Quanto voce deseja transferir para {contaDestino.Nome}");

                decimal valor = Convert.ToDecimal(Console.ReadLine());

                conta.Transferencia(contaDestino, valor);
            }
            else if (resposta == 6)
            {
                var contaInvestidor = (conta as ContaInvestimento);

                if (contaInvestidor.DinheiroInvestido)
                    throw new Exception("Seu dinheiro já está investido");

                ModelInvestimento escolhaInvestimento = View.EscolheInvestimentoView(app.TiposDeInvestimentos);

                int mesesParaDias = app.PassarTempo(escolhaInvestimento.TotalDeMeses);
                contaInvestidor.InvestimentoSolicitado(escolhaInvestimento, mesesParaDias);
                contaInvestidor.FazerInvestimento(escolhaInvestimento, mesesParaDias);
            }
            Console.ReadKey();

        }
        else if (opt == 3)
        {
            if (app.Contas.Count > 0)
            {
                int ContasDesejadas = View.ListarContas();
                dynamic ContaLista = app.DicionarioContasDiversas[ContasDesejadas].Count > 0
                ? app.DicionarioContasDiversas[ContasDesejadas]
                : throw new Exception("Não temos conta deste tipo cadastrada");

                foreach (dynamic conta in ContaLista)
                    conta.InformarDados();

                Console.ReadKey();
                continue;
            }

            throw new Exception("Não temos contas ainda!");
        }
        else if (opt == 4)
        {
            foreach (ContaBase conta in app.Contas)
            {
                if (conta.SaldoConta < 0)
                    Console.WriteLine($"{conta.Conta} {conta.SaldoConta}");
            }
        }
        else if (opt == 5)
        {
            int nConta = View.InformarcoesDeClientesView("Numero da conta: ");
            ContaBase conta = app.Contas.FirstOrDefault(x => x.Conta == nConta);

            if (conta == null)
                throw new Exception("Não achamos a conta deseja ");

            foreach (var tr in conta.Transacoes)
            {
                Console.WriteLine($"{tr.Categoria.Nome} => {tr.Valor:C2}  Data {tr.DataTransacao}");
            }
            Console.ReadKey();
        }
        else if (opt == 6)
        {
            if (app.TotalInvestido <= 0)
                throw new Exception("Não há dinheiro investido ainda");
            Console.WriteLine($"{app.TotalInvestido:C2}");
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