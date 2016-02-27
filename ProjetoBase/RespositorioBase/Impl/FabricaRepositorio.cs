using ProjetoBase.EntidadeBase.Generico;
using ProjetoBase.RespositorioBase.Interface;

namespace ProjetoBase.RespositorioBase.Impl
{
    public class FabricaRepositorio
    {
        public static IRepositorio<TEntidade> Construir<TEntidade>() where TEntidade : EntidadeBase<TEntidade>
        {
            return new RepositorioList<TEntidade>();
        }
    }
}
