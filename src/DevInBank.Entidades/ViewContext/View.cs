namespace DevInBank.Entidades.ViewContext {

    public static class View {

        public static int Menu(){
            Console.WriteLine("======= Painel =======");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("[1] Criar Conta");
            Console.WriteLine("======================");
            Console.WriteLine("Qual opção voce deseja ?");
            return int.Parse(Console.ReadLine());
        } 
    }
}