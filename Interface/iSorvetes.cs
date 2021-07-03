using System.Collections.Generic;

namespace Sabores
{
    public interface iSorvetes<T>
    {
        List<T> lista();
        T retornaID(int id);
        void adiciona(T entidade);
        void excluir(int id);
        void atualizar(int id, T entidade);
        int proxID();
    }
}