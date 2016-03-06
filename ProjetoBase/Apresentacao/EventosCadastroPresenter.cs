using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.Ferramentas.Utilitarios;

namespace ProjetoBase.Apresentacao
{
    public class EventosCadastroPresenter
    {
        public delegate IEnumerable<T> Listar<T>(int numeroPagina);

        public delegate bool Adicionar<T>(T entidade);

        public delegate bool Alterar<T>(T entidade);

        public delegate bool Remover<T>(T entidade);
    }
}
