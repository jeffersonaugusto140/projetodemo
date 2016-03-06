using ProjetoBase.EntidadeBase.Generico;

namespace ProjetoBaseTest.DTOs
{
    public class Endereco : EntidadeBase<Pessoa>
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }

        public enum EnTipoEndereco
        {
            Residencial = 1,
            Comercial = 2,
            Correspondencia = 3
        }
    }
}
