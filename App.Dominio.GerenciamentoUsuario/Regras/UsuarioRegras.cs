using App.Dominio.GerenciamentoUsuario.ObjetoDeValor;
using App.Dominio.ObjetoDeValor;

namespace App.Dominio.GerenciamentoUsuario.Regras
{
    public class UsuarioRegras
    {
        public static readonly RegraNegocio ConexaoUsuarioJaExiste = new RegraNegocio("Conexão já foi adicionada!");
        public static readonly RegraNegocio NaoPodeAdicionarUsuarioComMesmoId = new RegraNegocio("Não é possível conectar um usuário a ele mesmo.");
        public static readonly RegraNegocio DadosPessoaisJaCadastrados = new RegraNegocio("Dados pessoais já foram cadastrados.");
        public static readonly RegraNegocio UsuarioJaCadastrado = new RegraNegocio("Usuário já cadastrado.");
    }
}
