using System.Collections.Generic;
using System.Linq;
using App.Dominio.Generico;
using App.Dominio.Regras;
using App.Dominio.Validadores.Comum;

namespace App.Dominio.Entidades.Comum.Impl
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
            if (!this.EhValido())
                ;

            this.DadosPessoais = dadosPessoais;
        }

        public void AdicionarConexaoUsuario(Usuario conexaoUser)
        {
            if (this.ConexoesUsuarios.Any(x => x.Id == conexaoUser.Id))
                ;//throw new UsuarioExcecao(UsuarioRegras.ConexaoUsuarioJaExiste.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            if (this.Id == conexaoUser.Id)
                ;//throw new UsuarioExcecao(UsuarioRegras.NaoPodeAdicionarUsuarioComMesmoId.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            ConexoesUsuarios.Add(conexaoUser);
        }

        protected override void Validar()
        {
            var validator = new UsuarioValidator();
            _validationResult = validator.Validate(this);
        }
    }
}
