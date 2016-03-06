using ProjetoBase.EntidadeBase.Generico;

namespace ProjetoBaseTest.DTOs
{
    public class Telefone : EntidadeBase<Pessoa>
    {
        public string Numero { get; set; }
        public EnTipoTelefone TipoTelefone { get; set; }

        public enum EnTipoTelefone
        {
            Residencial = 1,
            Comercial = 2,
            Recado = 3,
            ReferenciaPessoal = 4,
            Celular = 5
        }
    }
}
