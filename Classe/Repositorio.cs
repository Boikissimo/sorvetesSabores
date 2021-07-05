using System;
using System.Collections.Generic;

namespace Sabores
{
    public class massaRepositorio : iSorvetes<massa>
    {
        private List<massa> listaMassa = new List<massa>();
        public string excluir(int id)
        {
            listaMassa[id].excluir();
            string mensagem = "";
            mensagem += "O sabor " + listaMassa[id].sabor + ", do tipo massa foi excluido." + Environment.NewLine;
            return mensagem;
        }
        public void adiciona(massa objeto)
        {
            listaMassa.Add(objeto);
        }
        public List<massa> lista()
        {
            return listaMassa;
        }
        public int proxID()
        {
            return listaMassa.Count;
        }
        public massa retornaID(int id)
        {
            return listaMassa[id];
        }
        public string producao(int id, uint producao)
        {
            listaMassa[id].quantidade += checked((int)producao);
            return "quantidade atual: " + listaMassa[id].quantidade;
        }
        public string venda(int id, uint venda)
        {
            listaMassa[id].quantidade -= checked((int)venda);
            return "quantidade restante: " + listaMassa[id].quantidade;
        }
    }
    public class picoleRepositorio : iSorvetes<picole>
    {
        private List<picole> listaPicole = new List<picole>();
        public string excluir(int id)
        {
            listaPicole[id].excluir();
            string mensagem = "";
            mensagem += "O sabor " + listaPicole[id].sabor + ", do tipo massa foi excluido." + Environment.NewLine;
            return mensagem;
        }
        public void adiciona(picole objeto)
        {
            listaPicole.Add(objeto);
        }
        public List<picole> lista()
        {
            return listaPicole;
        }
        public int proxID()
        {
            return listaPicole.Count;
        }
        public picole retornaID(int id)
        {
            return listaPicole[id];
        }
        public string producao(int id, uint producao)
        {
            listaPicole[id].quantidade += checked((int)producao);
            return "quantidade atual: " + listaPicole[id].quantidade;
        }
        public string venda(int id, uint venda)
        {
            listaPicole[id].quantidade -= checked((int)venda);
            return "quantidade restante: " + listaPicole[id].quantidade;
        }
    }
}