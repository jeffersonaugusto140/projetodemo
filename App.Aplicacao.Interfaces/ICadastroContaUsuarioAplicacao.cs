using System.Collections.Generic;
using App.Aplicacao.DTO;
using App.Aplicacao.Interfaces.Generico;

namespace App.Aplicacao.Interfaces
{
    public interface ICadastroContaUsuarioAplicacao : IAplicacao
    {
        void CadastrarUsuario(UsuarioPessoaDTO usuarioPessoaDto);
        void AlterarUsuario(UsuarioPessoaDTO usuarioPessoaDto);
        void AlterarSenhaUsuario(UsuarioPessoaDTO usuarioPessoaDto);

        IEnumerable<ClubeEsportivoDTO> ListarClubesEsportivos();
    }
}