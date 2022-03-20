using DevInBank.Entidades.CpfContext;
using DevInBank.Entidades.EnumAgencia;
using DevInBank.Entidades.ContaContext;

//var cpf = new Cpf("183.160.997-56");
//Console.WriteLine(cpf.ValidarCpf());
//new GeradorConta().GerarNumeros();

var conta1 = new ContaCorrente("andre", "183.160.997-56", "Rua do figo", 500, 200);
conta1.Saque(210);
Console.WriteLine(conta1.Saldo());
conta1.Depositar(100);

Console.WriteLine(conta1.Saldo());