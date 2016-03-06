using System.Collections.Generic;
using App.Aplicacao.DTO;
using App.Aplicacao.Interfaces;
using App.Comuns.Ferramentas;
using App.Dominio.Entidades.Comum.Impl;
using App.Dominio.Servicos.Interfaces;
using AutoMapper;

namespace App.Aplicacao
{
    public class CadastroContaUsuarioAplicacao : ICadastroContaUsuarioAplicacao
    {
        private readonly IUsuarioServico _usuarioServico;

        public void CadastrarUsuario(UsuarioPessoaDTO usuarioPessoaDto)
        {
            var usuario = usuarioPessoaDto.ConverterParaEntidade().Cast<Usuario>();
            _usuarioServico.Adicionar(usuario);
        }
        
        public void AlterarUsuario(UsuarioPessoaDTO usuarioPessoaDto)
        {
            throw new System.NotImplementedException();
        }

        public void AlterarSenhaUsuario(UsuarioPessoaDTO usuarioPessoaDto)
        {
            throw new System.NotImplementedException();
        }

        public CadastroContaUsuarioAplicacao(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }
    }
}
