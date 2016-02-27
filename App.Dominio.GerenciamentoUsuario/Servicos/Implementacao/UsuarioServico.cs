using App.Dominio.GerenciamentoUsuario.Entidades;
using App.Dominio.GerenciamentoUsuario.Excecoes;
using App.Dominio.GerenciamentoUsuario.Regras;
using App.Dominio.GerenciamentoUsuario.Servicos.Interfaces;
using App.Dominio.GerenciamentoUsuario.Servicos.Repositorio;

namespace App.Dominio.GerenciamentoUsuario.Servicos.Implementacao
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IPessoaRepositorio pessoaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
        }

        public void Adicionar(Usuario usuario)
        {
            var usuarioNoContexto = _usuarioRepositorio.BuscarPorLogin(usuario.Login);

            if (usuarioNoContexto != null)
                throw new UsuarioExcecao(UsuarioRegras.UsuarioJaCadastrado.Descricao);

            var pessoaNoContexto = _pessoaRepositorio.BuscarPorEmail(usuario.DadosPessoais.EmailOpcao1);

            if (pessoaNoContexto != null)
                throw new UsuarioExcecao(PessoaRegras.EmailJaCadastrado.Descricao);

            pessoaNoContexto = _pessoaRepositorio.BuscarPorEmail(usuario.DadosPessoais.EmailOpcao2);

            if (pessoaNoContexto != null)
                throw new UsuarioExcecao(PessoaRegras.EmailJaCadastrado.Descricao);

            _usuarioRepositorio.Adicionar(usuario);
        }
    }
}
