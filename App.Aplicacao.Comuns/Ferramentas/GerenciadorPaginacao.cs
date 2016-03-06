using System;
using System.Collections.Generic;
using System.Linq;
using App.Dominio.Generico;
using App.Dominio.Repositorio;

namespace App.Aplicacao.Comuns.Ferramentas
{
    public class GerenciadorPaginacao<T> where T : EntidadeBase
    {
        private readonly IListador<T> _listador;

        public int TotalItens => _listador.ListarTodos().Count();

        public int ItensPorPagina { get; set; }

        public int PaginaAtual { get; set; }

        public int TotalPagina => Convert.ToInt32(Math.Ceiling((decimal)TotalItens / ItensPorPagina));

        public GerenciadorPaginacao(IListador<T> listador)
        {
            _listador = listador;
            ItensPorPagina = 10;
        }

        public IEnumerable<T> BuscarPaginaAtual()
        {
            return BuscarPagina(this.PaginaAtual);
        }

        public IEnumerable<T> BuscarProxima()
        {
            int p = PaginaAtual + 1;

            if (p > TotalItens)
                p = PaginaAtual;

            return BuscarPagina(PaginaAtual = p);
        }

        public IEnumerable<T> BuscarAnterior()
        {
            int p = PaginaAtual - 1;

            if (p < TotalItens)
                p = PaginaAtual;

            return BuscarPagina(PaginaAtual = p);
        }

        public IEnumerable<T> BuscarPagina(int numeroPagina)
        {
            PaginaAtual = numeroPagina;

            return _listador.ListarTodos()
                //.OrderBy(x => x)
                .Skip((numeroPagina - 1) * ItensPorPagina)
                .Take(ItensPorPagina)
                .ToList();
        }

    }
}
