using App.Comuns.Excecoes;
using App.Dominio.Entidades.Comum.Impl;
using App.Dominio.Regras;
using App.Dominio.Regras.Comum;
using App.Dominio.Repositorio.Comum;
using App.Dominio.Servicos.Interfaces;

namespace App.Dominio.Servicos.Implementacao
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
            if (usuario.EhInvalido())
                throw new ValidadorException(validationFailures: usuario.ListarErros());

            var usuarioNoContexto = _usuarioRepositorio.BuscarPorLogin(usuario.Login);

            if (usuarioNoContexto != null)
                throw new ValidadorException(
                    message: UsuarioRegras.UsuarioJaCadastrado.Descricao,
                    mostrarParaUsuario: true,
                    ehSomenteAlerta: true);

            var pessoaNoContexto = _pessoaRepositorio.BuscarPorEmail(usuario.DadosPessoais.EmailOpcao1);

            if (pessoaNoContexto != null)
                throw new ValidadorException(
                    message: PessoaRegras.EmailJaCadastrado.Descricao,
                    mostrarParaUsuario: true,
                    ehSomenteAlerta: true);

            pessoaNoContexto = _pessoaRepositorio.BuscarPorEmail(usuario.DadosPessoais.EmailOpcao2);

            if (pessoaNoContexto != null)
                throw new ValidadorException(
                    message: PessoaRegras.EmailJaCadastrado.Descricao,
                    mostrarParaUsuario: true,
                    ehSomenteAlerta: true);

            _usuarioRepositorio.Adicionar(usuario);
            _pessoaRepositorio.Adicionar(usuario.DadosPessoais);
        }
    }
}
