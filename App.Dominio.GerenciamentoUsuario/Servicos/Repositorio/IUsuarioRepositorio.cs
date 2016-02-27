using App.Dominio.GerenciamentoUsuario.Entidades;
using App.Dominio.Repositorio;

namespace App.Dominio.GerenciamentoUsuario.Servicos.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario BuscarPorLogin(string login);
    }
}
