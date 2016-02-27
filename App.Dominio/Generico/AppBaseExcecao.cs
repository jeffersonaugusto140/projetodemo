using System;
using System.Runtime.Serialization;

namespace App.Dominio.Generico
{
    public class AppBaseExcecao : Exception
    {
        public bool MostrarParaUsuario { get; set; }
        public bool EhSomenteAlerta { get; set; }

        public AppBaseExcecao(string message) : base(message)
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        public AppBaseExcecao(string message, Exception innerException) : base(message, innerException)
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        protected AppBaseExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        public AppBaseExcecao()
        {
            this.MostrarParaUsuario = false;
            this.EhSomenteAlerta = false;
        }

        public AppBaseExcecao(string message, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        public AppBaseExcecao(string message, Exception innerException, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, innerException)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        protected AppBaseExcecao(SerializationInfo info, StreamingContext context, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(info, context)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }

        public AppBaseExcecao(bool mostrarParaUsuario, bool ehSomenteAlerta)
        {
            MostrarParaUsuario = mostrarParaUsuario;
            EhSomenteAlerta = ehSomenteAlerta;
        }
    }
}
