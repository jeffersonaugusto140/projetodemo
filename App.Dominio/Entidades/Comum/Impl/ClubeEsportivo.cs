
using App.Dominio.Generico;

namespace App.Dominio.Entidades.Comum.Impl
{
    public class ClubeEsportivo : EntidadeBase
    {
        public string Nome { get; set; }
        public EnTipoClubeEsportivo TipoClubeEsportivo { get; set; }
        public byte[] Logomarca { get; set; }

        protected override void Validar()
        {
            throw new System.NotImplementedException();
        }

        public enum EnTipoClubeEsportivo
        {
            FutebolCampo = 1,
            FutebolSalao = 2,
            Basquete = 3,
            Volei = 4
        }
    }
}
