using App.Dominio.ObjetoDeValor;

namespace App.Dominio.Regras.Comum
{
    public class PessoaRegras
    {
        public static readonly RegraNegocio ClubeJaSelecionado = new RegraNegocio("Clube já foi selecionado.");
        public static readonly RegraNegocio OrganizacaoEsportivaJaExisteNaoPodeSerAdicionada = 
            new RegraNegocio("Organização esportiva já foi adicionada.");
        public static readonly RegraNegocio EmailJaCadastrado = new RegraNegocio("E-mail já cadastrado.");
    }
}
