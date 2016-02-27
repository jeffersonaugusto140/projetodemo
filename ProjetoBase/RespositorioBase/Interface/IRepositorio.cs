using System;
using System.Collections.Generic;

namespace ProjetoBase.RespositorioBase.Interface
{
    public interface IRepositorio<TEntidade> : IListador<TEntidade>, IDisposable where TEntidade : EntidadeBase.Generico.EntidadeBase<TEntidade>
    {
        TEntidade Adicionar(TEntidade entidade);
        bool Adicionar(IEnumerable<TEntidade> entidades);

        TEntidade Alterar(TEntidade entidade);
        bool Alterar(IEnumerable<TEntidade> entidades);

        bool Remover(TEntidade entidade);
        bool Remover(IEnumerable<TEntidade> entidades);

        TEntidade BuscarPorId(UInt32 id);
    }
}