using System;
using System.Collections.Generic;

namespace ProjetoBase.RespositorioBase.Interface
{
    public interface IListador<TEntidade> : IDisposable where TEntidade : EntidadeBase.Generico.EntidadeBase<TEntidade>
    {
        IEnumerable<TEntidade> ListarTodos(bool incluirInativos = false);
    }
}