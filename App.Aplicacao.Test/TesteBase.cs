using App.Aplicacao.MapperDTO;

namespace App.Aplicacao.Test
{
    public class TesteBase
    {
        public TesteBase()
        {
            InicializadorMapper.Inicializar();
        }
    }
}
