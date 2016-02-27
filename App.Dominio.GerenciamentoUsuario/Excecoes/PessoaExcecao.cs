using System;
using System.Runtime.Serialization;

namespace App.Dominio.GerenciamentoUsuario.Excecoes
{
    public class PessoaExcecao : ExcecaoEntidadeBase
    {
        public PessoaExcecao(string message = "Ocorreu um erro inesperado!") : base(message)
        {
        }

        public PessoaExcecao(string message, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, mostrarParaUsuario, ehSomenteAlerta)
        {
        }

        public PessoaExcecao(string message, Exception innerException, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, innerException, mostrarParaUsuario, ehSomenteAlerta)
        {
        }

        public PessoaExcecao(SerializationInfo info, StreamingContext context, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(info, context, mostrarParaUsuario, ehSomenteAlerta)
        {
        }

        public PessoaExcecao(bool mostrarParaUsuario, bool ehSomenteAlerta) : base(mostrarParaUsuario, ehSomenteAlerta)
        {
        }
    }
}
