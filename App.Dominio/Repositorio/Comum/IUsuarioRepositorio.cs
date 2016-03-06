using App.Dominio.Entidades.Comum.Impl;

namespace App.Dominio.Repositorio.Comum
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario BuscarPorLogin(string login);
    }
}
