using System;
using System.Collections.Generic;
using App.Dominio.Generico;

namespace App.Dominio.Repositorio
{
    public interface IRepositorio<TEntidade> : IListador<TEntidade> where TEntidade : EntidadeBase
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