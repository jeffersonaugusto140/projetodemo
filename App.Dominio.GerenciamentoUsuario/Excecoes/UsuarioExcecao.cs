using System;
using System.Runtime.Serialization;

namespace App.Dominio.GerenciamentoUsuario.Excecoes
{
    public class UsuarioExcecao : ExcecaoEntidadeBase
    {
        public UsuarioExcecao(string message = "Ocorreu um erro inesperado!") : base(message)
        {
        }

        public UsuarioExcecao(string message, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, mostrarParaUsuario, ehSomenteAlerta)
        {
        }

        public UsuarioExcecao(string message, Exception innerException, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, innerException, mostrarParaUsuario, ehSomenteAlerta)
        {
        }

        public UsuarioExcecao(SerializationInfo info, StreamingContext context, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(info, context, mostrarParaUsuario, ehSomenteAlerta)
        {
        }

        public UsuarioExcecao(bool mostrarParaUsuario, bool ehSomenteAlerta) : base(mostrarParaUsuario, ehSomenteAlerta)
        {
        }
    }
}
