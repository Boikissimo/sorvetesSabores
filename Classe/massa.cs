using System;

namespace Sabores
{
    public class massa : Sorvete
    {  
        //Atributos
        private massaEmbalagem embalagem {get; set;}
        private ushort tamanhoML {get; set;} /*optei por usar short com base de ml por ter maior precisão e consumir menos espaço e processamento que pontos decimais, e também não
        acredito que este programa será usado por empresas grandes, que produzem caixas maiores do que 65L*/

        //metodos
        public massa(int id, string sabor, int quantidade, massaEmbalagem embalagem, ushort tamanhoML)
        {
            this.id = id;
            this.sabor = sabor;
            this.tipo = (tipo)1;
            this.quantidade = quantidade;
            this.ativo = true;
            this.embalagem = embalagem;
            this.tamanhoML = tamanhoML;
        }
        public override string ToString()
        {
            string descrição = "";
            descrição += "tipo: " + this.tipo + Environment.NewLine;
            descrição += "sabor: " + this.sabor + Environment.NewLine;
            descrição += "embalagem: " + this.embalagem + Environment.NewLine;
            descrição += "tamanhoML: " + this.tamanhoML + Environment.NewLine;
            descrição += "quantidade: " + this.quantidade + Environment.NewLine;
            descrição += "ativo: " + this.ativo + Environment.NewLine;
            return descrição;
        }
        public void excluir() 
        {
            this.ativo = false;
        }
        public bool retornaExcluido()
		{
			return this.ativo;
		}
        public string retornaSabor()
		{
			return this.sabor;
		}
		public int retornaId()
		{
			return this.id;
		}
    }
}