using System;
using System.Runtime.Serialization;

namespace App.Comuns.Excecoes
{
    public class AppBaseException : Exception
    {
        public bool MostrarParaUsuario { get; set; }
        public bool EhSomenteAlerta { get; set; }

        public AppBaseException(string message) : base(message)
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        public AppBaseException(string message, Exception innerException) : base(message, innerException)
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        protected AppBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        public AppBaseException()
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        public AppBaseException(string message, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        public AppBaseException(string message, Exception innerException, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, innerException)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        protected AppBaseException(SerializationInfo info, StreamingContext context, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(info, context)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        public AppBaseException(bool mostrarParaUsuario, bool ehSomenteAlerta)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }
    }
}
