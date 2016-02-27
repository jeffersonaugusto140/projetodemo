using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.Ferramentas.Mensagens;

namespace ProjetoBase.ExceptionsExtension
{
    public class RegistroInexistenteException : ExcecaoGenericaException
    {
        public RegistroInexistenteException(string message, Exception innerException, bool mostraParaUsuario, EnTipoExcecao tipoExcecao) : base(message, innerException, mostraParaUsuario, tipoExcecao)
        {
        }

        public RegistroInexistenteException(bool mostraParaUsuario = false) 
            : base(MensagensSistema.Instancia.RegistroInexitente, EnTipoExcecao.Alerta, mostraParaUsuario)
        {
        }
    }
}
