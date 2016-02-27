using System.Linq;
using App.Dominio.GerenciamentoUsuario.Entidades;
using App.Dominio.GerenciamentoUsuario.Servicos.Repositorio;
using App.Infra.Repositorio.Generico;

namespace App.Infra.Repositorio
{
    public class UsuarioRepositorio : RepositorioDados<Usuario>, IUsuarioRepositorio
    {
        public Usuario BuscarPorLogin(string login)
        {
            return Set.Where(x => x.Login.Equals(login)).SingleOrDefault();
        }
    }
}
