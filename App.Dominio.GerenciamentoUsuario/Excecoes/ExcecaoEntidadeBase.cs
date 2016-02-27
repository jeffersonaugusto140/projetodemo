using System;
using System.Runtime.Serialization;
using App.Dominio.Generico;

namespace App.Dominio.GerenciamentoUsuario.Excecoes
{
    public abstract class ExcecaoEntidadeBase : AppBaseExcecao
    {
        protected ExcecaoEntidadeBase(string message = "Ocorreu um erro inesperado!") : base(message)
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        protected ExcecaoEntidadeBase(string message, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        protected ExcecaoEntidadeBase(string message, Exception innerException, bool mostrarParaUsuario, bool ehSomenteAlerta) : 
            base(message, innerException)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        protected ExcecaoEntidadeBase(SerializationInfo info, StreamingContext context, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(info, context)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        protected ExcecaoEntidadeBase(bool mostrarParaUsuario, bool ehSomenteAlerta)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }
    }
}
