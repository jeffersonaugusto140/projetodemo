using System.Collections.Generic;
using App.Aplicacao.DTO;
using App.Aplicacao.DTO.Generico;

namespace App.Aplicacao.Interfaces.Generico
{
    public interface IGerenciamento<T> : IAplicacao where T : DTOGenerico
    {
        void Adicionar(T dto);
        void Alterar(T dto);
        void Inativar(T dto);
        IEnumerable<T> ListarOrganizacaoEsportiva(UsuarioPessoaDTO usuarioPessoaDto);
    }
}