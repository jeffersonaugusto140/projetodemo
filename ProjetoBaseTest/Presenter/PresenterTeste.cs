using System.Linq;
using NUnit.Framework;
using ProjetoBase.Apresentacao.Interfaces;
using ProjetoBase.Ferramentas.Utilitarios;
using ProjetoBase.RespositorioBase.Impl;
using ProjetoBaseTest.DTOs;
using ProjetoBaseTest.Presenter;

namespace ProjetoBaseTest.Apresentacao
{
    [TestFixture]
    public class PresenterTeste
    {
        private ICadastroBasePresenter<Pessoa> _presenter;
        private const int MaximoRegistroLista = 500;
        private const int NumeroRegistroPorPagina = 10;

        [SetUp]
        public void SetUp()
        {
            var rep = FabricaRepositorio.Construir<Pessoa>();

            var pag = new GerenciadorPaginacao<Pessoa>(rep) { ItensPorPagina = NumeroRegistroPorPagina };

            _presenter = new CadastroPessoaPresenterTeste(pag);
            
            Enumerable.Range(0, MaximoRegistroLista).ToList().ForEach(i =>
            {
                var p = Pessoa.CriarPessoPadrao();
                p.Nome = p.Nome + " " + i;
                rep.Adicionar(p);
            });

        }

        [Test]
        public void ListarPagina2()
        {
            int numeroPagina = 2;

            var result = _presenter.Listar(numeroPagina);

            CollectionAssert.IsNotEmpty(result);
            Assert.AreEqual(NumeroRegistroPorPagina, result.Count());
            Assert.AreEqual(numeroPagina, _presenter.Paginacao.PaginaAtual);
        }

        [Test]
        public void ListarPagina20()
        {
            int numeroPagina = 20;

            var result = _presenter.Listar(numeroPagina);

            CollectionAssert.IsNotEmpty(result);
            Assert.AreEqual(NumeroRegistroPorPagina, result.Count());
            Assert.AreEqual(numeroPagina, _presenter.Paginacao.PaginaAtual);
        }
    }
}
