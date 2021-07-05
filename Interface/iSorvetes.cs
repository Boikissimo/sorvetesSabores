using System.Collections.Generic;

namespace Sabores
{
    public interface iSorvetes<tipo>
    {
        List<tipo> lista();
        tipo retornaID(int id);
        void adiciona(tipo entidade);
        string excluir(int id);
        string producao(int id, uint produzido);
        string venda(int id, uint venda);
        int proxID();
    }
}