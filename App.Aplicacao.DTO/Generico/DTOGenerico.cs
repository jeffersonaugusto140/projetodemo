
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("App.Aplicacao")]
namespace App.Aplicacao.DTO.Generico
{
    
    public abstract class DTOGenerico
    {
        public long Id { get; set; }

        internal abstract object ConverterParaEntidade();
    }
}