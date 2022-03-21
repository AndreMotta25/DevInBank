namespace DevInBank.Entidades.AgenciaContext {
    
    public class Agencia{
        public Agencia(string name, string codigo)
        {
            Name = name;
            Codigo = codigo;
        }

        public string Name { get; private set; }
        public string Codigo { get; private set; }
    }
}