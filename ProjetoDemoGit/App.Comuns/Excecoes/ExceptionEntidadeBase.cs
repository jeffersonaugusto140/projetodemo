using System;
using System.Runtime.Serialization;

namespace App.Comuns.Excecoes
{
    public abstract class ExceptionEntidadeBase : AppBaseException
    {
        protected ExceptionEntidadeBase(string message = "Ocorreu um erro inesperado!") : base(message)
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        protected ExceptionEntidadeBase(string message, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        protected ExceptionEntidadeBase(string message, Exception innerException, bool mostrarParaUsuario, bool ehSomenteAlerta) : 
            base(message, innerException)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        protected ExceptionEntidadeBase(SerializationInfo info, StreamingContext context, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(info, context)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        protected ExceptionEntidadeBase(bool mostrarParaUsuario, bool ehSomenteAlerta)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }
    }
}
