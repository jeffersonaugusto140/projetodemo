
using App.Aplicacao.DTO.Generico;

namespace App.Aplicacao.DTO
{
    public class ClubeEsportivoDTO : DTOGenerico
    {
        public string Nome { get; set; }
        public EnTipoClubeEsportivoDTO TipoClubeEsportivo { get; set; }
        public byte[] Logomarca { get; set; }

        public enum EnTipoClubeEsportivoDTO
        {
            FutebolCampo = 1,
            FutebolSalao = 2,
            Basquete = 3,
            Volei = 4
        }
    }
}
