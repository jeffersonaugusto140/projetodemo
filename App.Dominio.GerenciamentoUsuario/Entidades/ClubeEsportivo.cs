
using App.Dominio.Generico;

namespace App.Dominio.GerenciamentoUsuario.Entidades
{
    public class ClubeEsportivo : EntidadeBase
    {
        public string Nome { get; set; }
        public EnTipoClubeEsportivo TipoClubeEsportivo { get; set; }
        public byte[] Logomarca { get; set; }

        public enum EnTipoClubeEsportivo
        {
            FutebolCampo = 1,
            FutebolSalao = 2,
            Basquete = 3,
            Volei = 4
        }
    }
}
