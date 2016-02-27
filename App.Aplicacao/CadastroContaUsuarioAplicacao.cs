using System.Collections.Generic;
using App.Aplicacao.DTO;
using App.Aplicacao.Interfaces;
using App.Dominio.GerenciamentoUsuario.Entidades;
using App.Dominio.GerenciamentoUsuario.Servicos.Interfaces;
using AutoMapper;

namespace App.Aplicacao
{
    public class CadastroContaUsuarioAplicacao : ICadastroContaUsuarioAplicacao
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly IPessoaServico _pessoaServico;

        public void CadastrarUsuario(UsuarioPessoaDTO usuarioPessoaDto)
        {
            var usuario = Mapper.Map<Usuario>(usuarioPessoaDto);
            var pessoa = Mapper.Map<Pessoa>(usuarioPessoaDto);

            usuario.DadosPessoais = pessoa;

            var sss = Mapper.Map<UsuarioPessoaDTO>(usuario);

            _usuarioServico.Adicionar(usuario);
            _pessoaServico.Adicionar(pessoa);
        }

        public IEnumerable<ClubeEsportivoDTO> ListarClubesEsportivos()
        {
            return null;
        }

        public void AlterarUsuario(UsuarioPessoaDTO usuarioPessoaDto)
        {
            throw new System.NotImplementedException();
        }

        public void AlterarSenhaUsuario(UsuarioPessoaDTO usuarioPessoaDto)
        {
            throw new System.NotImplementedException();
        }

        public CadastroContaUsuarioAplicacao(IUsuarioServico usuarioServico, IPessoaServico pessoaServico)
        {
            _usuarioServico = usuarioServico;
            _pessoaServico = pessoaServico;
        }
    }
}
