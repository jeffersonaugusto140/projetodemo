using System.Collections.Generic;
using ProjetoBase.EntidadeBase.Generico;
using ProjetoBase.Ferramentas.Utilitarios;

namespace ProjetoBase.Apresentacao.Interfaces
{
    public interface ICadastroBasePresenter<T> where T : EntidadeBase<T>
    {
        event EventosCadastroPresenter.Adicionar<T> OnAdicionar;
        event EventosCadastroPresenter.Alterar<T> OnAlterar;
        event EventosCadastroPresenter.Remover<T> OnRemover;
        bool Adicionar(T entidade);
        bool Alterar(T entidade);
        bool Remover(T entidade);
        IEnumerable<T> Listar(int numeroPagina);
        GerenciadorPaginacao<T> Paginacao { get; set; }
        IIngracaoCadastroBasePresenter IngracaoCadastroBasePresenter { get; set; }
    }

}