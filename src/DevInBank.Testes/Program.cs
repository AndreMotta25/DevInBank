using DevInBank.Entidades.CpfContext;
using DevInBank.Entidades.EnumAgencia;
using DevInBank.Entidades.ContaContext;
using DevInBank.Entidades.TransferenciaContext;


var transferencia = new List<Transferencia>();


var conta1 = new ContaCorrente("andre", "183.160.997-56", "Rua do figo", 500, 200, transferencia);
var conta2 = new ContaCorrente("livia", "162.842.397-85", "Rua do figo", 200, 300, transferencia);
var conta3 = new ContaCorrente("andre", "183.160.997-56", "Rua do figo", 500, 200, transferencia);

//conta1.Saque(210);
Console.WriteLine(conta1.Saldo());
//conta1.Depositar(100);

conta1.Transferencia(conta3,100);
//Console.WriteLine(conta1.Saldo());
//Console.WriteLine();
//conta1.Extrato();

foreach(var tr in transferencia) {
    Console.WriteLine(tr.ContaDestino.Nome);
}
conta1.Extrato();
//conta2.Extrato();


/*
    so pode existir uma conta corrente por usuario(delimitar pelo cpf) quando o usuario escolher o tipo de conta corrente e passar o 
    cpf vamos verificar se ja nao existe uma conta corrente com o mesmo cpf
*/ 