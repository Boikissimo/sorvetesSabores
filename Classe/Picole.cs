using System;

namespace Sabores
{
    public class picole : Sorvete
    {
        //atributo
        private basePicolé liquidoBase {get; set;}
        //optei por não colocar variações de tamanho do picolé, reduzindo o consumo de memória.

        //metodo
        public picole(int id, string sabor, int quantidade, bool ativo, basePicolé liquido)
        {
            this.id = id;
            this.sabor = sabor;
            this.tipo = (tipo)2;
            this.quantidade = quantidade;
            this.ativo = true;
            this.liquidoBase = liquido;
        }
        public override string ToString()
        {
            string descrição = "";
            descrição += "tipo: " + this.tipo + Environment.NewLine;
            descrição += "sabor: " + this.sabor + Environment.NewLine;
            descrição += "liquido: " + this.liquidoBase + Environment.NewLine;
            descrição += "quantidade: " + this.quantidade + Environment.NewLine;
            descrição += "ativo: " + this.ativo + Environment.NewLine;
            return descrição;
        }
        public void excluir() 
        {
            this.ativo = false;
        }
    }
}