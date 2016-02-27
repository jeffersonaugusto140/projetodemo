using System.Collections.Generic;
using System.Linq;
using App.Dominio.Generico;
using App.Dominio.GerenciamentoUsuario.Excecoes;
using App.Dominio.GerenciamentoUsuario.Regras;

namespace App.Dominio.GerenciamentoUsuario.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public virtual Pessoa DadosPessoais { get; set; }
        public virtual ICollection<Usuario> ConexoesUsuarios { get; set; }

        public Usuario()
        {
            ConexoesUsuarios = new List<Usuario>();
        }

        public void AdicionarDadosPessoais(Pessoa dadosPessoais)
        {
            if (this.DadosPessoais != null)
                throw new UsuarioExcecao(UsuarioRegras.DadosPessoaisJaCadastrados.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            this.DadosPessoais = dadosPessoais;
        }

        public void AdicionarConexaoUsuario(Usuario conexaoUser)
        {
            if (this.ConexoesUsuarios.Any(x => x.Id == conexaoUser.Id))
                throw new UsuarioExcecao(UsuarioRegras.ConexaoUsuarioJaExiste.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            if (this.Id == conexaoUser.Id)
                throw new UsuarioExcecao(UsuarioRegras.NaoPodeAdicionarUsuarioComMesmoId.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            ConexoesUsuarios.Add(conexaoUser);
        }
    }
}
