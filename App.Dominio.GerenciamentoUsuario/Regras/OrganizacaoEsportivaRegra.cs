using App.Dominio.GerenciamentoUsuario.ObjetoDeValor;
using App.Dominio.ObjetoDeValor;

namespace App.Dominio.GerenciamentoUsuario.Regras
{
    public class OrganizacaoEsportivaRegra
    {
        public static readonly RegraNegocio MemborJaFoiAdicionado = new RegraNegocio("Membro já foi adicionado.");
        public static readonly RegraNegocio JaExisteUsuarioCriador = new RegraNegocio("Criador já foi adicionado.");
        public static readonly RegraNegocio JaFoiAdicionadoComoAdm = new RegraNegocio("Usuário já foi adicionado como adiministrador.");
        public static readonly RegraNegocio AdministradorDeveSerMembro = new RegraNegocio("Para adicionar administrador primeiro deve-se tornar membro.");
    }
}
