namespace ProjetoBase.Ferramentas.Mensagens.Interface
{
    public interface IMensagensSistema
    {
        string RegistroInexitente { get; }
        string OperacaoNaoPermitida { get; }
        string SucessoRealizarOperacao { get; }
    }
}