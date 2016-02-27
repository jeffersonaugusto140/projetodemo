using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.Apresentacao.Interfaces;

namespace ProjetoBase.Apresentacao.Tipos
{
    public class IntegracaoPresenter : Dictionary<EnPresenter, IIngracaoCadastroBasePresenter>
    {

    }

    public enum EnPresenter
    {
        Endereco = 1,
        Telefone = 2
    }
}
