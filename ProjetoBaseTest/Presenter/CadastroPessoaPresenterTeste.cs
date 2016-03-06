using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.Apresentacao;
using ProjetoBase.Ferramentas.Utilitarios;
using ProjetoBaseTest.DTOs;

namespace ProjetoBaseTest.Presenter
{
    public class CadastroPessoaPresenterTeste : CadastroBasePresenter<Pessoa>
    {
        public CadastroPessoaPresenterTeste(GerenciadorPaginacao<Pessoa> paginacao) : base(paginacao)
        {
        }
    }
}
