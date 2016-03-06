using System;
using System.Collections.Generic;
using App.Dominio.Generico;

namespace App.Dominio.Repositorio
{
    public interface IListador<out TEntidade> : IDisposable where TEntidade : EntidadeBase
    {
        IEnumerable<TEntidade> ListarTodos(bool incluirInativos = false);
    }
}