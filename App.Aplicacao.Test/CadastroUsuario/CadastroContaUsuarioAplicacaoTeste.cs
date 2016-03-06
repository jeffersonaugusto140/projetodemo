using System;
using App.Aplicacao.DTO;
using App.Aplicacao.Interfaces;
using App.Comuns.Excecoes;
using App.Dominio.Repositorio.Comum;
using App.Dominio.Servicos.Implementacao;
using App.Dominio.Servicos.Interfaces;
using App.Infra.Repositorio;
using LinqKit;
using NUnit.Framework;

namespace App.Aplicacao.Test.CadastroUsuario
{
    [TestFixture]
    public class CadastroContaUsuarioAplicacaoTeste : TesteBase
    {
        private UsuarioPessoaDTO _usuarioPessoaDto;
        private ICadastroContaUsuarioAplicacao _cadastro;
        private readonly IUsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();
        private readonly IPessoaRepositorio _pessoaRepositorio = new PessoaRepositorio();

        [SetUp]
        public void Init()
        {
            IUsuarioServico usuarioServico = new UsuarioServico(_usuarioRepositorio, _pessoaRepositorio);

            _cadastro = new CadastroContaUsuarioAplicacao(usuarioServico);
        }

        [Test]
        public void CadastrarNovoUsuario()
        {
            try
            {
                _usuarioPessoaDto = new UsuarioPessoaDTO();
                _usuarioPessoaDto.Login = "teste@teste.com.br";
                _usuarioPessoaDto.Senha = "123";
                _usuarioPessoaDto.Nome = "Nome";
                _usuarioPessoaDto.SobreNome = "SobreNome";
                _usuarioPessoaDto.EmailOpcao1 = "email@email.com";
                _usuarioPessoaDto.DataNascimento = DateTime.Now.AddYears(-20);

                _cadastro.CadastrarUsuario(_usuarioPessoaDto);

                var usuario = _usuarioRepositorio.BuscarPorId(1);
                var pessoa = _pessoaRepositorio.BuscarPorId(1);

                Assert.IsNotNull(usuario);
                Assert.IsNotNull(pessoa);

                Assert.AreEqual(usuario.Login, _usuarioPessoaDto.Login);
                Assert.AreEqual(usuario.Senha, _usuarioPessoaDto.Senha);
                Assert.AreEqual(pessoa.Nome, _usuarioPessoaDto.Nome);
                Assert.AreEqual(pessoa.SobreNome, _usuarioPessoaDto.SobreNome);
                Assert.AreEqual(pessoa.EmailOpcao1, _usuarioPessoaDto.EmailOpcao1);

                Assert.AreEqual(usuario.DadosPessoais.Id, 1);
            }
            catch (ValidadorException exception)
            {
                exception.Erros.ForEach(x => System.Diagnostics.Debug.WriteLine(x));
            }
        }
        [Test]
        public void CadastrarNovoUsuarioInvalido()
        {
            try
            {
                _usuarioPessoaDto = new UsuarioPessoaDTO();
                
                _cadastro.CadastrarUsuario(_usuarioPessoaDto);
            }
            catch (ValidadorException exception)
            {
                exception.Erros.ForEach(x => System.Diagnostics.Debug.WriteLine(x));
            }
        }
    }
}
