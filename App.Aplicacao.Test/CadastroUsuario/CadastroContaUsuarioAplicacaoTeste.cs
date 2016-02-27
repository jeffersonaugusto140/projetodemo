using App.Aplicacao.DTO;
using App.Aplicacao.Interfaces;
using App.Dominio.GerenciamentoUsuario.Servicos.Implementacao;
using App.Dominio.GerenciamentoUsuario.Servicos.Interfaces;
using App.Dominio.GerenciamentoUsuario.Servicos.Repositorio;
using App.Infra.Repositorio;
using NUnit.Framework;

namespace App.Aplicacao.Test.CadastroUsuario
{
    [TestFixture]
    public class CadastroContaUsuarioAplicacaoTeste : TesteBase
    {
        private UsuarioPessoaDTO _usuarioPessoaDto;
        private ClubeEsportivoDTO _clubeEsportivoDto;
        private ICadastroContaUsuarioAplicacao _cadastro;
        private readonly IUsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();
        private readonly IPessoaRepositorio _pessoaRepositorio = new PessoaRepositorio();

        [SetUp]
        public void Init()
        {
            IUsuarioServico usuarioServico = new UsuarioServico(_usuarioRepositorio, _pessoaRepositorio);
            IPessoaServico pessoaServico = new PessoaServico(_pessoaRepositorio);

            _cadastro = new CadastroContaUsuarioAplicacao(usuarioServico, pessoaServico);
        }

        [Test]
        public void CadastrarNovoUsuario()
        {
            _usuarioPessoaDto = new UsuarioPessoaDTO();
            _clubeEsportivoDto = new ClubeEsportivoDTO
            {
                Nome = "Barcelona"
            };
            
            _usuarioPessoaDto.Login = "teste@teste.com.br";
            _usuarioPessoaDto.Senha = "123";
            _usuarioPessoaDto.Nome = "Nome";
            _usuarioPessoaDto.EmailOpcao1 = "email@email.com";
            _usuarioPessoaDto.ClubesDeInteresse.Add(_clubeEsportivoDto);

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
    }
}
