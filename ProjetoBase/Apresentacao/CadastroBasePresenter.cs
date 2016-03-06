using System.Collections.Generic;
using ProjetoBase.Apresentacao.Interfaces;
using ProjetoBase.EntidadeBase.Generico;
using ProjetoBase.Ferramentas.Utilitarios;

namespace ProjetoBase.Apresentacao
{
    public abstract class CadastroBasePresenter<T> : ICadastroBasePresenter<T> where T : EntidadeBase<T>
    {
        public event EventosCadastroPresenter.Adicionar<T> OnAdicionar;
        public event EventosCadastroPresenter.Alterar<T> OnAlterar;
        public event EventosCadastroPresenter.Remover<T> OnRemover;

        public bool Adicionar(T entidade)
        {
            if (OnAdicionar != null)
                return OnAdicionar(entidade);
            return false;
        }
        public bool Alterar(T entidade)
        {
            if (OnAlterar != null)
                return OnAlterar(entidade);
            return false;
        }
        public bool Remover(T entidade)
        {
            if (OnRemover != null)
                return OnRemover(entidade);
            return false;
        }
        public IEnumerable<T> Listar(int numeroPagina)
        {
            if (Paginacao != null)
                return Paginacao.BuscarPagina(numeroPagina);
            return null;
        }
        
        public GerenciadorPaginacao<T> Paginacao { get; set; }

        public IIngracaoCadastroBasePresenter IngracaoCadastroBasePresenter { get; set; }

        protected CadastroBasePresenter(GerenciadorPaginacao<T> paginacao)
        {
            Paginacao = paginacao;
        }
    }
}