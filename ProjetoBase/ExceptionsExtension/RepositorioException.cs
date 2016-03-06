using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.ExceptionsExtension
{
    public class RepositorioException : ExcecaoGenericaException
    {
        public RepositorioException(string message, Exception innerException, bool mostraParaUsuario, EnTipoExcecao tipoExcecao) : base(message, innerException, mostraParaUsuario, tipoExcecao)
        {
        }

        public RepositorioException(string message, EnTipoExcecao tipoExcecao = EnTipoExcecao.Erro, bool mostraParaUsuario = false) 
            : base(message, tipoExcecao, mostraParaUsuario)
        {
        }
    }

    public class AdicionarRepositorioException : ExcecaoGenericaException
    {
        public AdicionarRepositorioException(Exception innerException, string mensagem = "Erro ao adicionar registro.")
            : base(mensagem, innerException, false, EnTipoExcecao.Erro)
        {
        }
        
        public AdicionarRepositorioException(string mensagem = "Erro ao adicionar registro.") : base(mensagem, EnTipoExcecao.Erro, false)
        {
        }
    }

    public class AlterarRepositorioException : ExcecaoGenericaException
    {
        public AlterarRepositorioException(Exception innerException, string mensagem = "Erro ao alterar registro.")
            : base(mensagem, innerException, false, EnTipoExcecao.Erro)
        {
        }

        public AlterarRepositorioException(string mensagem = "Erro ao alterar registro.") : base(mensagem, EnTipoExcecao.Erro, false)
        {
        }
    }

    public class RemoverRepositorioException : ExcecaoGenericaException
    {
        public RemoverRepositorioException(Exception innerException, string mensagem = "Erro ao remover registro.")
            : base(mensagem, innerException, false, EnTipoExcecao.Erro)
        {
        }

        public RemoverRepositorioException(string mensagem = "Erro ao remover registro.") : base(mensagem, EnTipoExcecao.Erro, false)
        {
        }
    }

    public class ListarRepositorioException : ExcecaoGenericaException
    {
        public ListarRepositorioException(Exception innerException, string mensagem = "Erro ao listar registros.")
            : base(mensagem, innerException, false, EnTipoExcecao.Erro)
        {
        }

        public ListarRepositorioException(string mensagem = "Erro ao listar registros.") : base(mensagem, EnTipoExcecao.Erro, false)
        {
        }
    }
}
