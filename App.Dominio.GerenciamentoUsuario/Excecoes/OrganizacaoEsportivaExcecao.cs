using System;

namespace App.Dominio.GerenciamentoUsuario.Excecoes
{
    public class OrganizacaoEsportivaExcecao : ExcecaoEntidadeBase
    {
        public OrganizacaoEsportivaExcecao(string message = "Ocorreu um erro inesperado!") : base(message)
        {
        }

        public OrganizacaoEsportivaExcecao(string message, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, mostrarParaUsuario, ehSomenteAlerta)
        {
        }

        public OrganizacaoEsportivaExcecao(string message, Exception innerException, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, innerException, mostrarParaUsuario, ehSomenteAlerta)
        {
        }
    }
}
