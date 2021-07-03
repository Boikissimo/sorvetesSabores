namespace Sabores
{
    public class massa : Sorvete
    {  
        //Atributos
        private massaEmbalagem embalagem {get; set;}
        private ushort tamanhoML {get; set;} /*optei por usar short com base de ml por ter maior precisão e consumir menos espaço e processamento que pontos decimais, e também não
        acredito que este programa será usado por empresas grandes, que produzem caixas maiores do que 65l*/
    }
}