using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.ExceptionsExtension
{
    public class ExcecaoGenericaException : Exception
    {
        public bool MostraParaUsuario { get; private set; }
        public EnTipoExcecao TipoExcecao { get; private set; }

        public ExcecaoGenericaException(string message, Exception innerException, bool mostraParaUsuario, EnTipoExcecao tipoExcecao)
            : base(message, innerException)
        {
            MostraParaUsuario = mostraParaUsuario;
            TipoExcecao = tipoExcecao;
        }

        public ExcecaoGenericaException(string message, EnTipoExcecao tipoExcecao = EnTipoExcecao.Erro, bool mostraParaUsuario = false) : base(message)
        {
            MostraParaUsuario = mostraParaUsuario;
            TipoExcecao = tipoExcecao;
        }

        public override string StackTrace => this.Trace();

        public enum EnTipoExcecao
        {
            Erro = 1,
            Alerta = 2
        }
    }
}
