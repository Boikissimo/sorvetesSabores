namespace Sabores
{
    public abstract class Sorvete
    {  
        public int id {get; protected set;}
        public string sabor {get; protected set;}
        public tipo tipo {get; protected set;}
        public int quantidade {get; protected set;}
        public bool ativo {get; protected set;}
    }
}